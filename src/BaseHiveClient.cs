using RestSharp;
using RestSharp.Authenticators;
using HiveSharp.Models;
using System.Threading.Tasks;
using HiveSharp.Auth;
using System.Collections.Generic;
using System;
using HiveSharp.Data;

namespace HiveSharp
{
    /// <summary>
    /// Base class for classes calling any of the "beekeeper" Hive endpoints.
    /// </summary>
    public abstract class BaseHiveClient
    {
        protected string Username { get; set; }
        protected string Password { get; set; }

        protected BaseHiveClient(string username, string password)
        {
            Username = username;
            Password = password;
        }

        /// <summary>
        /// Gets a Hive client with the jwt added as an auth header.
        /// </summary>
        /// <returns>An authenticated client.</returns>
        public async Task<RestClient> GetAuthenticatedClient()
        {
            var client = GetClient();
            client.Authenticator = new JwtAuthenticator(await GetToken());
            return client;
        }

        /// <summary>
        /// Gets a <see cref="RestClient"/> with the base url set to the beekeeper api root.
        /// </summary>
        /// <returns>A <see cref="RestClient"/>.</returns>
        public RestClient GetClient()
        {
            return new RestClient(Endpoints.BaseUrl);
        }

        /// <summary>
        /// Calls the "admin-login" endpoint and returns the deserialised response as an <see cref="AdminLoginResponse"/>.
        /// </summary>
        /// <returns>An <see cref="AdminLoginResponse"/>.</returns>
        public async Task<AdminLoginResponse> GetAdmin()
        {
            var client = await GetAuthenticatedClient();
            var request = new RestRequest(Endpoints.AdminLogin, Method.POST);
            request.AddJsonBody(new
            {
                token = await GetToken(),
                actions = true,
                devices = true,
                homes = true,
                products = true
            });

            var response = await client.ExecuteAsync<AdminLoginResponse>(request);

            return response.Data;
        }

        /// <summary>
        /// Calls the 'products' endpoint and returns the list.
        /// </summary>
        /// <returns>A list of <see cref="Product"/>.</returns>
        public async Task<List<Product>> GetProducts()
        {
            var client = await GetAuthenticatedClient();
            var request = new RestRequest(Endpoints.Products, Method.GET);
            request.AddJsonBody(new
            {
                token = await GetToken()
            });

            var response = await client.ExecuteAsync<List<Product>>(request);

            return response.Data;
        }

        /// <summary>
        /// Gets the JWT.
        /// </summary>
        protected async Task<string> GetToken()
        {
            // TODO: Cache
            var hiveAuth = new HiveAuth();
            var token = await hiveAuth.GetUserToken(Username, Password);
            return token;
        }
    }
}

