using System.Threading.Tasks;
using Kanye.API.Model;

namespace Kanye.API.Services;

public interface IKanyeApiClient
{
    Task<KanyeResponse> GetKanyeQuoteResponse();
    Task<HttpResponseMessage> AddCommentQuote(CommentRequest commentRequest);
}