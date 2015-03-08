using System;
using Everest;
using Everest.Content;
using Everest.Pipeline;
using Everest.Status;
using MindServer.Domain.DataContracts;
using MindServer.Tests.Properties;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MindServer.Tests.AcceptanceTests
{
    [TestFixture]
    [Category("AcceptanceTests")]
    public class AccountControllerAcceptanceTests
    {
        private const string MediaApiUrl = "admin/login";

        //[Test]
        public void Index_AdminUserLogIn_OkHttpStatusCodeAndSuccessResponse()
        {
            Console.WriteLine("Base URL:" + Settings.Default.BaseUrl);
            var adminLogInRequest = new AdminLogInRequest
            {
                EmailAddress = "jonny@jonnypillar.co.uk",
                Password = "123abc"
            };

            var everest = new RestClient(Settings.Default.BaseUrl);

            var bodyContent = new JsonBodyContent(JsonConvert.SerializeObject(adminLogInRequest));

            everest.Post(MediaApiUrl, bodyContent, new PipelineOption[]
            {
                ExpectStatus.OK
            });
        }
    }
}