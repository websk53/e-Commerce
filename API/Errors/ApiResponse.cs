using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLitePCL;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statuscode, string message = null)
        {
            StatusCode = statuscode;
            Message = message ?? GetDefaultMessageForStatusCode(statuscode);
        }
        public int StatusCode {get; set;}
        public string Message {get; set;}

        private string GetDefaultMessageForStatusCode(int statuscode)
        {
            return statuscode switch
            {
                400 => "Bad Request",
                401 => "Not Authorised",
                404 => "Resource not found",
                500 => "Server Error",
                _ => null
            };
        }
    }
}