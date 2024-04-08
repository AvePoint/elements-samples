# Elements.Client\Api.ElementsConnectApi

Method | Description
------------- | -------------
[**Connect-Elements**](ElementsConnectApi.md#connect-elements) | Connect to Elements Public API with Client credentials or Client Secret.
[**Disconnect-Elements**](ElementsConnectApi.md#disconnect-elements) | Disconnect from Elements Public API.

<a name="connect-elements"></a>
# **Connect-Elements**
The first way
> Connect-Elements<br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-Url] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-ClientId] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-Cert] <X509Certificate2><br>

Connect to Elements Public API with Client credentials.

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **Url** | **String**| The public API URL varies with your data center, You can find it in Elements user guide. 
 **ClientId** | **String**| The application (client) ID you have retrieved from AvePoint Online Service app registrations. 
 **Cert** | **X509Certificate2**| The corresponding .pfx certificate file of the .cer certificate you used while registering the AvePoint app. 

### Example
```powershell
Connect-Elements -Url 'https://graph-public.sharepointguild.com/partner' -ClientId '06367378-7a45-4edc-b3a0-0fa51a74e865' -Cert $certificate
```
You can construct the $certificate parameter by the following two ways:
```powershell
# Get from .pfx file with the password
$certificate = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2 "path_to_pfx_file", "password"

# Get from certificate store of local machine by certificate thumbprint, you need install the certificate to local machine in advance and replace the certificate thumbprint to yours
$certificate = (Get-ChildItem -Path 'Cert:\LocalMachine\My\your thumbprint' -Recurse)[0]
```

The second way
> Connect-Elements<br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-Url] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-ClientId] <String><br>
> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[-ClientSecret] <String><br>

Connect to Elements Public API with Client Secret.

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **Url** | **String**| The public API URL varies with your data center, You can find it in Elements user guide. 
 **ClientId** | **String**| The application (client) ID you have retrieved from AvePoint Online Service app registrations. 
 **ClientSecret** | **String**| The client secret you have retrieved from AvePoint Online Service app registrations. 

### Example
```powershell
Connect-Elements -Url 'https://graph-public.sharepointguild.com/partner' -ClientId '06367378-7a45-4edc-b3a0-0fa51a74e865' -ClientSecret 'your secret'
```

[[Back to top]](#) [[Back to API list]](ElementsApi.md#documentation-for-cmdlets) [[Back to README]](../README.md)

<a name="disconnect-elements"></a>
# **Disconnect-Elements**
> Disconnect-Elements<br>

Disconnect from Elements Public API.

### Example
```powershell
Disconnect-Elements
```

[[Back to top]](#) [[Back to API list]](ElementsApi.md#documentation-for-cmdlets) [[Back to README]](../README.md)
