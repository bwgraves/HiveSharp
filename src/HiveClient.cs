using RestSharp;
using RestSharp.Authenticators;
using HiveSharp.Models;
using System.Threading.Tasks;

namespace HiveSharp
{
    /// <summary>
    /// Base class for classes calling any of the "beekeeper" Hive endpoints.
    /// </summary>
    public abstract class BaseHiveClient
    {
        /// <summary>
        /// Gets a Hive client with the jwt added as an auth header.
        /// </summary>
        /// <returns>An authenticated client.</returns>
        public RestClient GetAuthenticatedClient()
        {
            var client = GetClient();
            client.Authenticator = new JwtAuthenticator(GetToken());
            return client;
        }

        /// <summary>
        /// Gets a <see cref="RestClient"/> with the base url set to the beekeeper api root.
        /// </summary>
        /// <returns>A <see cref="RestClient"/>.</returns>
        public RestClient GetClient()
        {
            return new RestClient("https://beekeeper-uk.hivehome.com/1.0");
        }

        /// <summary>
        /// Calls the "admin-login" endpoint and returns the deserialised response as an <see cref="AdminLoginResponse"/>.
        /// </summary>
        /// <returns>An <see cref="AdminLoginResponse"/>.</returns>
        public async Task<AdminLoginResponse> GetAdmin()
        {
            var client = GetAuthenticatedClient();
            var request = new RestRequest("auth/admin-login", Method.POST);
            request.AddJsonBody(new
            {
                token = GetToken(),
                actions = true,
                devices = true,
                homes = true,
                products = true
            });
            var response = await client.ExecuteAsync<AdminLoginResponse>(request);

            return response.Data;
        }

        /// <summary>
        /// Gets the JWT.
        /// TODO: Get it from somewhere automatically.
        /// </summary>
        /// <returns></returns>
        protected string GetToken()
        {
            // Need to get the bearer token from somewhere
            return "<THE JWT>";
        }
    }
}

