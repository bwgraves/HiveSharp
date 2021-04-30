using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HiveSharp
{
    /// <summary>
    /// A class containg methods to control Hive heating devices.
    /// </summary>
    public class HeatingClient : BaseHiveClient
    {
        /// <summary>
        /// Boosts the heating!
        /// </summary>
        /// <param name="heatingId">The product id of the heating device.</param>
        /// <param name="minutes">The number of minutes to boost the heating for.</param>
        /// <param name="target">The target temperature.</param>
        /// <returns>Returns true if the request returned a 200 status code, otherwise false.</returns>
        public async Task<bool> BoostHeating(string heatingId, int minutes, decimal target)
        {
            var request = new RestRequest($"nodes/heating/{heatingId}", Method.POST);
            request.AddJsonBody(new
            {
                mode = "BOOST",
                boost = minutes,
                target,
            });

            var result = await GetAuthenticatedClient().ExecuteAsync(request);

            return result.StatusCode == HttpStatusCode.OK;
        }
    }
}
