using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Website.Shared;

namespace Website.Client.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static bool IsClientError(this HttpResponseMessage message)
        {
            var code = (int)message.StatusCode;
            return code is >= 400 and < 500;
        }

        public static Task<ApiError> ToApiError(this HttpResponseMessage message)
            => message.Content.ReadFromJsonAsync<ApiError>();
    }
}