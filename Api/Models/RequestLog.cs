using System;

namespace Api.Models
{
    public class RequestLog
    {
        public RequestLog(string scheme, 
            string host, 
            string path, 
            string queryString, 
            string body)
        {
            Scheme = scheme;
            Host = host;
            Path = path;
            QueryString = queryString;
            Body = body;
        }

        public string Scheme { get; set; }
        public string Host { get; set; }
        public string Path { get; set; }
        public string QueryString { get; set; }
        public string Body { get; set; }

        public override string ToString()
        {
            return 
                "Http Request Information "+
                $"{Environment.NewLine} " +
                $"Schema:{Scheme} " +
                $"{Environment.NewLine} " +
                $"Host: {Host} " +
                $"{Environment.NewLine} " +
                $"Path: {Path} " +
                $"{Environment.NewLine} " +
                $"QueryString: {QueryString} " +
                $"{Environment.NewLine} " +
                $"Request Body: {Body}";
        }
    }
}
