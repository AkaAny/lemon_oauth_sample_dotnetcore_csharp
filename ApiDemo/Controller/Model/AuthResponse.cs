using System;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo
{
    public class AuthResponse
    {
        [FromQuery(Name = "code")]
        public String Code { get; set; }
        [FromQuery(Name = "state")]
        public String State { get; set; }
    }
}