using Amazon;
using HiveSharp.Data;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HiveSharp.Auth
{
    /// <summary>
    /// Helper class for getting credentials.
    /// </summary>
    public static class CredentialHelper
    {
        /// <summary>
        /// Gets the credentials needed passed to the amazon cognito provider scraping the hive sso login page.
        /// </summary>
        /// <returns>A populated <see cref="AmazonCredentials"/>.</returns>
        public static async Task<AmazonCredentials> GetCredentials()
        {
            var client = new HttpClient();

            var response = await client.GetAsync(Endpoints.LoginUrl);

            var contents = await response.Content.ReadAsStringAsync();
            var document = new HtmlDocument();
            document.LoadHtml(contents);

            var values = document.DocumentNode.SelectSingleNode("//script").InnerHtml.Split(',').Select(x => x.Substring(7)).ToList();

            var properties = new Dictionary<string, string>();

            values.ForEach(property =>
            {
                var pair = property.Split('=');
                properties.Add(pair[0], pair[1].Trim('"'));
            });

            return new AmazonCredentials
            {
                ClientId = properties["HiveSSOPublicCognitoClientId"],
                PoolName = properties["HiveSSOPoolId"].Split('_')[1],
                Region = RegionEndpoint.EUWest1
            };
        }
    }
}
