using ConsumerService.Enums;

namespace ConsumerService.Models
{
    public class CustomResponse
    {
     
        public ResponseCode statuscode { get; set; }
        public string message { get; set; }
        public object data { get; set; }

        public CustomResponse(ResponseCode statuscode, string message, object data)
        {
            this.statuscode = statuscode;
            this.message = message;
            this.data = data;
        }
    }
}
