using System;
using System.Collections.Specialized;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;

namespace ApiDemo
{
    public class OAuthFactory
    {
        private readonly IConfiguration _configuration;
        public OAuthFactory()
        {
            this._configuration= new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("oauth.json")
                            .Build();
        }
        public OAuth Get(String service)
        {
            return _configuration.GetSection(service).Get<OAuth>();
        }
    }
}