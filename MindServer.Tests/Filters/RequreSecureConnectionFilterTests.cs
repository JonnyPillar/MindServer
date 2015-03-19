using System;
using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MindServer.Filters;
using Moq;
using NUnit.Framework;

namespace MindServer.Tests.Filters
{
    internal class RequreSecureConnectionFilterTests
    {
        //private AuthorizationContext _filterContext;
        //private Mock<HttpRequestBase> _request;

        //[SetUp]
        //public void SetUp()
        //{
        //    var @params = new NameValueCollection();
        //    var responseHeaders = new NameValueCollection();

        //    _request = new Mock<HttpRequestBase>();
        //    _request.SetupGet(x => x.Params).Returns(@params);
        //    //request.Params.Returns(@params);

        //    var response = new Mock<HttpResponseBase>();
        //    response.SetupGet(x => x.Headers).Returns(responseHeaders);
        //    //response.Headers.Returns(responseHeaders);

        //    var context = new Mock<HttpContextBase>();
        //    context.SetupGet(x => x.Request).Returns(_request.Object);
        //    context.SetupGet(x => x.Response).Returns(response.Object);
        //    //context.Request.Returns(request);
        //    //context.Response.Returns(response);

        //    var controller = new Mock<ControllerBase>();
        //    var actionDescriptor = new Mock<ActionDescriptor>();

        //    var controllerContext = new ControllerContext(context.Object, new RouteData(), controller.Object);
        //    _filterContext = new AuthorizationContext(controllerContext, actionDescriptor.Object);
        //}


        //[Test]
        //public void OnAuthorisation_NoContext_ThrowsException()
        //{
        //    var sut = new RequireHttpsMvcAttribute();
        //    Assert.Throws<ArgumentNullException>(() => sut.OnAuthorization(null));
        //}


        //[Test]
        //public void OnAuthorisation_LocalRequest_RequestNotRedirected()
        //{
        //    //Arrange
        //    _request.Setup(x => x.IsLocal).Returns(true);
        //    //request.IsLocal.Returns(true);
        //    var sut = new RequireHttpsMvcAttribute();

        //    // Act
        //    sut.OnAuthorization(_filterContext);

        //    // Assert - checking if we are not being redirected
        //    var redirectResult = _filterContext.Result as RedirectToRouteResult;
        //    Assert.Null(redirectResult);
        //}


        //[Test]
        //public void OnAuthorisation_NonLocalRequest_RedirectedToHttps()
        //{
        //    //Arrange
        //    _request.Setup(x => x.IsLocal).Returns(false);
        //    //request.IsLocal.Returns(false);
        //    var sut = new RequreSecureConnectionFilter();

        //    // Act && Assert 
        //    // here we check if controll is passed down to RequireHttpsAttribute code
        //    // and we are not testing for Microsoft code.
        //    Assert.Throws<InvalidOperationException>(() => sut.OnAuthorization(_filterContext));
        //}
    }
}