#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace ApiDemo
{
    public class HttpUtils
    {
        private static readonly HttpUtils Instance=new HttpUtils();

        public static HttpUtils GetInstance()
        {
            return Instance;
        }
        
        public string MakeGetUrl(string host, string subUrl, IDictionary<string, string>? queryMap)
        {
            string url = host + subUrl;
            var urlBuilder = HttpUtility.ParseQueryString(string.Empty);
            if (queryMap == null)
            {
                return url;
            }
            foreach (var pair in queryMap)
            {
                urlBuilder.Add(pair.Key, pair.Value);
            }
            return url + "?" + urlBuilder.ToString();
        }

        private readonly IDictionary<Type, JsonSerializerOptions> _optionCache=new Dictionary<Type, JsonSerializerOptions>();

        private JsonSerializerOptions GetOptionsByType<T>() where T:class
        {
            Type typeOfT = typeof(T);
            if (_optionCache.ContainsKey(typeOfT))
            {
                return _optionCache[typeOfT];
            }
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new DataConverter<T>());
            _optionCache.Add(typeOfT,options);
            return options;
        }
        
        public BaseResponse<T>? Get<T>(string url,IDictionary<string,string>? headerMap) where T : class
        {
            var options = GetOptionsByType<T>();
            using (HttpClient client = new HttpClient())
            {
                if (headerMap != null)
                {
                    foreach (var pair in headerMap)
                    {
                        client.DefaultRequestHeaders.Add(pair.Key, pair.Value);
                    }
                }
                var responseMsg = client.GetAsync(url).GetAwaiter().GetResult();
                return responseMsg.Content.ReadFromJsonAsync<BaseResponse<T>>(options).GetAwaiter().GetResult();
            }
        }

        public BaseResponse<T>? GetWithTokenAuthorization<T>(string url,string accessToken) where T:class
        {
            return Get<T>(url, new Dictionary<string, string>()
            {
                {"Authorization","token "+accessToken},
            });
        }
    }
}