using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIAutomation_YG.Utilities
{
    public static class Libraries
    {
        public static IRestResponse<T> ExecuteRequest<T>(this RestClient client, IRestRequest request) where T : new()
        {
            var response = client.Execute<T>(request);
            return response;
        }

        public static string GetNestedResponseObject(this IRestResponse response, string responseObject,
            string nestedResponseObject)
        {
            JObject obs = JObject.Parse(response.Content);
            return (string)obs[responseObject][nestedResponseObject];
        }
    }
}
