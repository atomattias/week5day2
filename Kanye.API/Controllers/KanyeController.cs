using System.Collections.Immutable;
using System.Net;
using System.Text.Json;
using Kanye.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http;
using Kanye.API.Services;
using Microsoft.AspNetCore.Http.Extensions;

namespace Kanye.API.Controllers;


[ApiController]
[Route("[controller]")]
public class KanyeController : ControllerBase
{
    private readonly IKanyeApiClient _kanyeApiClient;

    public KanyeController(IKanyeApiClient kanyeApiClient)
    {
        _kanyeApiClient = kanyeApiClient;
    }
    
    [HttpGet("/api/quote/")]
    public async Task<ActionResult<KanyeResponse>> GetKanyeQuote()
    {
        var kanyeResponse = await _kanyeApiClient.GetKanyeQuoteResponse();
        kanyeResponse.Id = Guid.NewGuid().ToString();
        kanyeResponse.ResponseAt = DateTime.Now;

        return kanyeResponse;
    }

    [HttpPost("api/quote/comment")]
    public async Task<ActionResult<HttpResponseMessage>> PostQuote(CommentRequest commentRequest)
    {
        return Created(new Uri(Request.GetEncodedUrl()), await _kanyeApiClient.AddCommentQuote(commentRequest));
    }
}