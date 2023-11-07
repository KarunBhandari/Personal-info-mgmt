using ClassLibrary;
using ConsumingWebAPI.Utility;
using DocumentFormat.OpenXml.InkML;

namespace ConsumingWebAPI.Factory
{
    internal static class AoiClientFactory
    {
        private static Uri apiUri;
        private static Lazy<AoiClient> restClient = new Lazy<AoiClient>(
            () => new AoiClient(apiUri),
            LazyThreadSafetyMode.ExecutionAndPublication);

        static AoiClientFactory()
        {
            apiUri = new Uri(ApplicationSettings.WebApiUrl);
        }

        public static AoiClient Instance
            {
              get
               {
                 return restClient.Value;
               }
            }
    }
}
