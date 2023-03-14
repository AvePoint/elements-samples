$clientId = ''
$audience = 'https://identity.avepointonlineservices.com/connect/token'
$certificate = Get-ChildItem -Path Cert:\LocalMachine\My\{thumbprint}
$apiUrl = "https://graph.avepointonlineservices.com/partner/api/V1.1/Services"
$scopes = "partner.license.read.all"

$now = (Get-Date).ToUniversalTime()
$createDate = [Math]::Floor([decimal](Get-Date($now) -UFormat "%s"))
$expiryDate = [Math]::Floor([decimal](Get-Date($now.AddHours(1)) -UFormat "%s"))

$header = [Ordered]@{
    alg = "RS256"
    kid = $certificate.Thumbprint
    typ = "JWT"
} | ConvertTo-Json

$payloadJson = [Ordered]@{
    sub = $clientId
    jti = [guid]::NewGuid()
    nbf = $createDate
    exp = $expiryDate
    iat = $createDate
    iss = $clientId
    aud = $audience
} | ConvertTo-Json

Write-Verbose "Payload to sign: $payloadJson"
Write-Verbose "Signing certificate: $($cert.Subject)"

try { ConvertFrom-Json -InputObject $payloadJson -ErrorAction Stop | Out-Null } # Validating that the parameter is actually JSON - if not, generate breaking error
catch { throw "The supplied JWT payload is not JSON: $payloadJson" }

$encodedHeader = [Convert]::ToBase64String([System.Text.Encoding]::UTF8.GetBytes($header)) -replace '\+','-' -replace '/','_' -replace '='
$encodedPayload = [Convert]::ToBase64String([System.Text.Encoding]::UTF8.GetBytes($payloadJson)) -replace '\+','-' -replace '/','_' -replace '='

$jwt = $encodedHeader + '.' + $encodedPayload # The first part of the JWT

$toSign = [System.Text.Encoding]::UTF8.GetBytes($jwt)

$rsa = ([System.Security.Cryptography.X509Certificates.RSACertificateExtensions]::GetRSAPrivateKey($certificate))
if ($null -eq $rsa) { # Requiring the private key to be present; else cannot sign!
    throw "There's no private key in the supplied certificate - cannot sign" 
}
else {
    try { 
        $sig = [Convert]::ToBase64String($rsa.SignData($toSign,[Security.Cryptography.HashAlgorithmName]::SHA256,[Security.Cryptography.RSASignaturePadding]::Pkcs1)) -replace '\+','-' -replace '/','_' -replace '=' 
        $jwt = $jwt + '.' + $sig;
    }
    catch { throw "Signing with SHA256 and Pkcs1 padding failed using private key $rsa" }
}

# Create a hash with body parameters
$body = @{
    client_id = $clientId
    client_assertion = $jwt
    client_assertion_type = "urn:ietf:params:oauth:client-assertion-type:jwt-bearer"
    scope = $scopes
    grant_type = "client_credentials"
    
}

# Splat the parameters for Invoke-Restmethod for cleaner code
$postSplat = @{
    ContentType = 'application/x-www-form-urlencoded'
    Method = 'POST'
    Body = $body
    Uri = $audience
}
    
$request = Invoke-RestMethod @postSplat

# View access_token
$apiToken = $request.access_token
$apiHeaders = @{ 
    'Content-Type' = 'application/json'
    Accept = 'application/json'
    Authorization = "Bearer $apiToken" 
}
$apiResponse = Invoke-WebRequest -Method Get -Uri $apiUrl -Headers $apiHeaders -ErrorAction Stop
$api =  ($apiResponse.Content | ConvertFrom-Json)

Write-Output $api