using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Kanye.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Kanye.API.Services;

public class KanyeApiClient : IKanyeApiClient
{
    //private string url = @"https://api.kanye.rest";
    //private HttpClient client = new HttpClient();
    
    private static Task<Stream> GetHttpStreamTask(string url)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return client.GetStreamAsync(url);
    }
    
    public async Task<KanyeResponse> GetKanyeQuoteResponse()
    {
        string url = @"https://api.kanye.rest";
        return JsonSerializer.Deserialize<KanyeResponse>(await GetHttpStreamTask(url));
    }
    
    private static async Task<HttpResponseMessage> PostHttpStreamTask(string url, CommentRequest quote)
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
        var quoteStr = JsonSerializer.Serialize(quote);
        var content = new StringContent(quoteStr);
        var result =  client.PostAsync(url, content).Result;
        return result;
    }

    public async Task<HttpResponseMessage> AddCommentQuote(CommentRequest comment)
    { 
        
        string url = @"https://jsonplaceholder.typicode.com/posts";
        return await PostHttpStreamTask(url, comment);
        
         
    }
}