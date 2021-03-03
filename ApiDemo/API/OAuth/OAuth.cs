using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ApiDemo
{
    public class OAuth
    {
        public string Host { get; set; }
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUrl { get; set; }
        public string GetAuthUrl(String state)
        {
            return HttpUtils.GetInstance().MakeGetUrl(Host, "/oauth/authorize",
                new Dictionary<string, string>()
            {
                {"response_type", "code"},
                {"client_id", ClientID},
                {"redirect_uri", RedirectUrl},
                {"state", state},
            });
        }

        public BaseResponse<TokenResponse> GetAccessToken(string code)
        {
            string url = HttpUtils.GetInstance().MakeGetUrl(Host, "/oauth/token",
                new Dictionary<string, string>()
            {
                {"grant_type", "authorization_code"},
                {"client_id", ClientID},
                {"client_secret", ClientSecret},
                {"code", code},
            });
            return HttpUtils.GetInstance().Get<TokenResponse>(url,null);
        }

        public BaseResponse<ValidateResponse> Validate(string accessToken)
        {
            string url = HttpUtils.GetInstance().MakeGetUrl(Host, "/oauth/token/validate",
                null);
            return HttpUtils.GetInstance().GetWithTokenAuthorization<ValidateResponse>(url,accessToken);
        }
    }
}