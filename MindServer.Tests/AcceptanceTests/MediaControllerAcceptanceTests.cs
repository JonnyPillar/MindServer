using System;
using System.Security.Cryptography;
using Everest;
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
    public class MediaControllerAcceptanceTests
    {
        private const string MediaApiUrl = "api/media/";

        //[Test]
        public void Get_ValidRequest_ReturnsMediaItemJSON()
        {
            Console.WriteLine("Base URL:" + Settings.Default.BaseUrl);
            var everest = new RestClient(Settings.Default.BaseUrl);
            var response = everest.Get(MediaApiUrl + "getMediaFiles", new PipelineOption[]
            {
                ExpectStatus.OK
            });

            Assert.IsFalse(string.IsNullOrWhiteSpace(response.Body));
            var deserialisedBody  = JsonConvert.DeserializeObject<GetMediaResponse>(response.Body);

            Assert.IsTrue(deserialisedBody.Success);
            Assert.IsNullOrEmpty(deserialisedBody.Message);
            Assert.IsNotEmpty(deserialisedBody.MediaFiles);
        }
    }
}