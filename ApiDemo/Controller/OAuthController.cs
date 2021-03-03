using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;

namespace ApiDemo.Controller
{
    [ApiController]
    [Route("oauth")]
    public class OAuthController:ControllerBase
    {
        private readonly HttpContext _context;
        private readonly ILogger<OAuthController> _logger;
        private readonly OAuth _oauth;

        public OAuthController(IHttpContextAccessor contextAccessor,ILogger<OAuthController> logger,OAuthFactory oauthFactory)
        {
            this._context = contextAccessor.HttpContext;
            this._logger = logger;
            this._oauth= oauthFactory.Get("hduhelp");
        }
        
        [HttpGet("request")]
        public void RequestAuth()
        {
            String authUrl= _oauth.GetAuthUrl("this_is_a_state_to_prevent_csrf");
            _logger.LogInformation("auth url:"+authUrl);
            _context.Response.Redirect(authUrl);
        }

        [HttpGet("callback")]
        public object Callback([FromQuery] AuthResponse authResponse)
        {
            _logger.LogInformation("code:" + authResponse.Code + " " + "state:" + authResponse.State);
            BaseResponse<TokenResponse> tokenResponse = _oauth.GetAccessToken(authResponse.Code);
            if (!tokenResponse.IsSuccess())
            {
                _context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return StringResponse.Create(40100, "failed to get token");
            }
            BaseResponse<ValidateResponse> validateResponse = _oauth.Validate(tokenResponse.Data?.AccessToken);
            if (!validateResponse.IsSuccess())
            {
                _context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return StringResponse.Create(40100, "invalid token");
            }
            return InfoAPI.GetInstance().GetStudentInfo(validateResponse.Data?.AccessToken);
        }
    }
}