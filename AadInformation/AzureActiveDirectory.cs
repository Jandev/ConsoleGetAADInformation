using System;
using System.Threading.Tasks;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AadInformation
{
    internal class AzureActiveDirectory
    {
        public async Task MakeUserRequest()
        {
            var client = AuthenticationHelper.GetActiveDirectoryClientAsApplication();

            try
            {
                var users = await client.Users.OrderBy(user => user.DisplayName).ExecuteAsync();
                foreach (var user in users.CurrentPage)
                {
                    Console.WriteLine(user.DisplayName + " " + user.ObjectId);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        private static class AuthenticationHelper
        {
            public static ActiveDirectoryClient GetActiveDirectoryClientAsApplication()
            {
                Uri servicePointUri = new Uri(Settings.ResourceUrl);
                Uri serviceRoot = new Uri(servicePointUri, Settings.TenantId);
                ActiveDirectoryClient activeDirectoryClient = new ActiveDirectoryClient(
                    serviceRoot,
                    async () => await AcquireTokenAsyncForApplication());
                return activeDirectoryClient;
            }

            private static async Task<string> AcquireTokenAsyncForApplication()
            {
                AuthenticationContext authenticationContext = new AuthenticationContext(Settings.AuthString, false);

                ClientCredential clientCred = new ClientCredential(Settings.ClientId, Settings.ClientSecret);
                AuthenticationResult authenticationResult =
                    await authenticationContext.AcquireTokenAsync(
                        Settings.ResourceUrl,
                        clientCred);
                string token = authenticationResult.AccessToken;
                return token;
            }
        }
    }
}
