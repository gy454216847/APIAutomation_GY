using APIAutomation_YG.Base;
using APIAutomation_YG.Model;
using APIAutomation_YG.Utilities;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace APIAutomation_YG.Steps
{
    [Binding]
    public  sealed class AuthenticationSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private Settings _settings;

        /// <summary>
        /// This is the constructor for this binding class where the context is injected here.
        /// 4565456
        /// </summary>
        /// <param name="settings"></param>
        public AuthenticationSteps(Settings settings)
        {
            _settings = settings;
        }

        [Then(@"I should have the response with status code (.*)")]
        public void ThenIShouldHaveTheFollowingResponseWithStatusCode(string statusCode)
        {
            Assert.That(_settings.Response.StatusCode.ToString(), Is.EqualTo(statusCode),
                $"The statusCode is not matching");
        }

        [Given(@"I should save the (.*) from the response")]
        [Then(@"I should save the (.*) from the response")]
        public void ThenIShouldSaveFromTheResponse(string key)
        {
            var value = _settings.Response.GetNestedResponseObject("datas", key);
            ScenarioContext.Current.Add(key, value);
        }


        [Given(@"I perform a (.*) POST operation for (.*) with body")]
        public void GivenIPerformAPOSTOperationWithBody(string returnObjType, string url, Table table)
        {
            _settings.Request = new RestRequest(url, Method.POST);

            foreach (var row in table.Rows)
            {
                if (string.Equals(row[1], "username") || string.Equals(row[1], "password"))
                {
                    var rand = new Random();
                    int num = rand.Next(100000);
                    _settings.Request.AddParameter(row[0], row[1] + num);
                    ScenarioContext.Current.Add(row[0], row[1] + num);
                }
            }

            switch (returnObjType)
            {
                case "RegisterUser":
                    _settings.Response = _settings.RestClient.ExecuteRequest<RegisterUser>(_settings.Request);
                    break;
            }

        }
    }
}
