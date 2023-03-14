using IdentityModel;
using IdentityModel.Client;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ElementsClient
{
    internal class Program
    {
        private static readonly string identityServiceUrl = "https://identity.avepointonlineservices.com";
        private static readonly string clientId = "";
        private static readonly string certificateThumbprint = "{thumbprint}";
        private static readonly string scopes = "partner.license.read.all";

        private static readonly string endpoint = "https://graph.avepointonlineservices.com/partner/api/V1.1/Services";

        static async Task Main(string[] args)
        {

            var token = GetTokenAsync().GetAwaiter().GetResult();

            var result = EndpointRequest(token);

            Console.WriteLine(result);

            Console.ReadLine();
        }

        private static async Task<string> GetTokenAsync()
        {
            var token = string.Empty;
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync(identityServiceUrl);
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return token;
            }
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientAssertion = new ClientAssertion()
                {
                    Type = OidcConstants.ClientAssertionTypes.JwtBearer,
                    Value = CreateClientAuthJwt(disco)
                },
                Scope = scopes,
            });
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return token;
            }
            token = tokenResponse.AccessToken;
            return token;
        }


        private static string CreateClientAuthJwt(DiscoveryDocumentResponse response)
        {
            // set exp to 5 minutes
            var tokenHandler = new JwtSecurityTokenHandler { TokenLifetimeInMinutes = 5 };

            var securityToken = tokenHandler.CreateJwtSecurityToken(
                // iss must be the client_id of our application
                issuer: clientId,
                // aud must be the identity provider (token endpoint)
                audience: response.TokenEndpoint,
                // sub must be the client_id of our application
                subject: new ClaimsIdentity(
                  new List<Claim> { new Claim("sub", clientId),
                  new Claim("jti", Guid.NewGuid().ToString())}),
                // sign with the private key (using RS256 for IdentityServer)
                signingCredentials: new SigningCredentials(
                  new X509SecurityKey(new X509Certificate2(LoadCertificate(certificateThumbprint))), "RS256")
            );

            return tokenHandler.WriteToken(securityToken);
        }

        private static X509Certificate2 LoadCertificate(string certificateThumbprint)
        {
            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            var certificate = store.Certificates.Find(
                    X509FindType.FindByThumbprint,
                    certificateThumbprint,
                    false)[0];
            return certificate;
        }

        private static string EndpointRequest(string bearerToken) 
        {
            string result = string.Empty;
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (msg, cert, chain, err) => true
            };
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + bearerToken);
                var response = httpClient.GetAsync(endpoint).Result;
                if (response.IsSuccessStatusCode)
                {
                    Task<string> responseContent = response.Content.ReadAsStringAsync();
                    result = responseContent.Result;
                }
            }
            return result;
        }
    }
}