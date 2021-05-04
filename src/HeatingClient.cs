using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HiveSharp
{
    /// <summary>
    /// A class containg methods to control Hive heating devices.
    /// </summary>
    public class HeatingClient : BaseHiveClient
    {
        public HeatingClient(string username, string password) : base(username, password)
        {
        }

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

            var result = await (await GetAuthenticatedClient()).ExecuteAsync(request);

            return result.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// Gets the temperature from the given thermostat.
        /// </summary>
        /// <param name="thermostatId">The device id of the thermostat.</param>
        /// <returns>Returns the temperature.</returns>
        public async Task<double> GetTemperature(string thermostatId)
        {
            var thermostat = (await GetProducts()).FirstOrDefault(p => p.Id == thermostatId);

            if (thermostat == null)
            {
                throw new KeyNotFoundException("The thermostat with the given id couldn't be found.");
            }

            return thermostat.Props.Temperature;
        }
    }
}
