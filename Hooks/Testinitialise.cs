using System;
using TechTalk.SpecFlow;
using APIAutomation_YG.Base;

namespace APIAutomation_EJ.Hooks
{
    [Binding]
    public class TestInitialise
    {
        private Settings _settings;
        public TestInitialise(Settings settings)
        {
            _settings = settings;
        }

        [BeforeScenario]
        public void TestSetup()
        {
            //_settings.BaseUrl = new Uri(ConfigurationManager.AppSettings["baseUrl"].ToString());
            var baseUrl = "http://106.15.238.71:7413/";
            _settings.BaseUrl = new Uri(baseUrl.ToString());
            _settings.RestClient.BaseUrl = _settings.BaseUrl;
        }
    }
}
