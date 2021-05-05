using Amazon;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiveSharp.Auth
{
    /// <summary>
    /// Credentials object containg the values needed for the Amazon cognito provider.
    /// </summary>
    public class AmazonCredentials
    {
        public RegionEndpoint Region { get; set; }
        public string PoolName { get; set; }
        public string ClientId { get; set; }
    }
}
