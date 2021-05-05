namespace HiveSharp.Data
{
    /// <summary>
    /// A store of all of the api endpoints called in the library.
    /// </summary>
    public static class Endpoints
    {
        public static string LoginUrl => "https://sso.hivehome.com/";
        public static string BaseUrl => "https://beekeeper-uk.hivehome.com/1.0";
        public static string AdminLogin => "auth/admin-login";
        public static string Products => "products";
    }
}
