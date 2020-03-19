using APIAutomation_YG.Model;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;


namespace APIAutomation_YG
{
    
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public static void RegisterAccount()
        {
            //Creating Client connection 
            RestClient restClient = new RestClient(baseUrl: "http://106.15.238.71:7413");

            //Creating request to get data from server 
            RestRequest restRequest = new RestRequest(resource: "/e-store/authentication/register", Method.POST);

            Random random = new Random();
            int num = random.Next(maxValue: 99999);

            restRequest.AddParameter(name: "username", value: "username" + num);
            restRequest.AddParameter(name: "password", value: "password" + num);


            
            

            // Executing request to server and checking server response to the it 
            IRestResponse restResponse = restClient.Execute(restRequest); 
            


            
            //Extracting output data from received response
            RegisterUser newUser = new JsonDeserializer().Deserialize<RegisterUser>(restResponse);

            //Assert that correct Status is returned 
            Assert.That(newUser.code.ToString(), Is.EqualTo(expected: "200"), $"The status code is not matching");
        }
    }
}