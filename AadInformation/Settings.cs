using System.Configuration;

namespace AadInformation
{
    internal class Settings
    {
        public const string ResourceUrl = "https://graph.windows.net";
        public static string TenantId => ConfigurationManager.AppSettings["TenantId"];
        public static string TenantName => ConfigurationManager.AppSettings["TenantName"];
        public static string ClientId => ConfigurationManager.AppSettings["ClientId"];
        public static string ClientSecret => ConfigurationManager.AppSettings["ClientSecret"];
        public static string AuthString => "https://login.microsoftonline.com/" + TenantName; //"https://login.microsoftonline.com/" + TenantName;
    }
}
