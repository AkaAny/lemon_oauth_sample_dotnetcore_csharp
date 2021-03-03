using System;
using System.Collections.Generic;

namespace ApiDemo
{
    public class InfoAPI
    {
        private static readonly InfoAPI Instance=new InfoAPI();

        public static InfoAPI GetInstance()
        {
            return Instance;
        }
        
        private static readonly string Host = "https://api.hduhelp.com/base";
        public BaseResponse<PersonInfoResponse> GetPersonInfo(string accessToken)
        {
            string url= HttpUtils.GetInstance().MakeGetUrl(Host, "/person/info",
                null);
            return HttpUtils.GetInstance().GetWithTokenAuthorization<PersonInfoResponse>(url,accessToken);
        }

        public BaseResponse<StudentInfoResponse> GetStudentInfo(string accessToken)
        {
            string url= HttpUtils.GetInstance().MakeGetUrl(Host, "/student/info",
                null);
            return HttpUtils.GetInstance().GetWithTokenAuthorization<StudentInfoResponse>(url,accessToken);
        }
    }
}