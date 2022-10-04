using System;
using System.Net;
using Moq;
using Xunit;
using Kanye.API.Services;
using Kanye.API.Model;
using Kanye.API.Controllers;
using FluentAssertions;


namespace Kanye2.Tests;


public class Kanye2Tests
{
    private static Mock<IKanyeApiClient> _mock = new Mock<IKanyeApiClient>();
    
   // private KanyeController _Kanye = new KanyeController(_mock.Object);

    // [Fact]
    // public async void Should_Get_Quote_By_Id()
    // {
    //     mock.Setup(p => p.GetKanyeQuoteResponse());
    //
    //     KanyeController knaye = new KanyeController(mock.Object);
    //
    //     var resutl = await knaye.GetKanyeQuote();
    //
    //
    //     Assert.Equal("", resutl);
    //
    // }
    // [Fact]
    // public async void Get_qoute_details()
    // {
    //     var qouteDTO = new KanyeResponse()
    //     {

    //         Quote = "All the musicians will be free"

    //     };
    //     _mock.Setup(p => p.GetKanyeQuoteResponse().Result).Returns(qouteDTO);

    //     KanyeController _Kanye = new KanyeController(_mock.Object);

    //     var result = await _Kanye.GetKanyeQuote();
        

    //     Assert.True(qouteDTO.Equals(result.Value));
    //    // Assert.Equal(qouteDTO.Quote, result);
    //     //result.Should().Be(qouteDTO);

    // } 

    [Fact]
    public async void post_quote_should_be_successful() 
    {
        // arrange
        CommentRequest commentDTO = new CommentRequest() 
        {
            Id = 3, Title = "The Title", Body = "All proggrammers will be free!", UserId = "695u3"
        };

        HttpResponseMessage response = new HttpResponseMessage() 
        {
            StatusCode = HttpStatusCode.Created
        };

        _mock.Setup(api => api.AddCommentQuote(commentDTO).Result).Returns(response);

        // act
       KanyeController _Kanye = new KanyeController(_mock.Object);
        var result = await _Kanye.PostQuote(commentDTO);

        // assert
        Assert.True(response.StatusCode.Equals(result.Value));
    }

}