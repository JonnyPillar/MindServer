using System;
using Everest;
using Everest.Pipeline;
using Everest.Status;
using MindServer.Tests.Properties;
using NUnit.Framework;

namespace MindServer.Tests.AcceptanceTests
{
    [TestFixture]
    [Category("AcceptanceTests")]
    public class MediaControllerAcceptanceTests
    {
        private string _mediaApiUrl = "api/media/";

        [Test]
        public void Get_ValidRequest_ReturnsMediaItemJSON()
        {
            Console.WriteLine("Base URL:" + Settings.Default.BaseUrl);
            var everest = new RestClient(Settings.Default.BaseUrl);
            var result = everest.Get(_mediaApiUrl + "getMediaFiles", new PipelineOption[]
            {
                ExpectStatus.OK
            });

            Assert.IsFalse(string.IsNullOrWhiteSpace(result.Body));
        }
    }
}