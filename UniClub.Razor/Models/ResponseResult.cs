using System.Net;

namespace UniClub.Razor.Models
{
    public class ResponseResult
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Data { get; set; }
    }
}
