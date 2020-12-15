﻿using System;

namespace Api.Models
{
    public class ResponseLog
    {
        public ResponseLog(int statusCode, string body)
        {
            StatusCode = statusCode;
            Body = body;
        }

        public int StatusCode { get; private set; }
        public string Body { get; private set; }

        public override string ToString()
        {
            return "Http Response Information" +
                $"{Environment.NewLine} " +
                $"Status Code: {StatusCode}" +
                $"{Environment.NewLine} " +
                $"Body : {Body}";
        }
    }
}
