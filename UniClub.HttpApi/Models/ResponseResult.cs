using System.Net;

namespace UniClub.HttpApi.Models
{
    public class ResponseResult
    {
        public HttpStatusCode StatusCode { get; set; }
        public object Data { get; set; }
    }
}
