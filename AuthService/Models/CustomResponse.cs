namespace AuthService.Models
{
    public class CustomResponse
    {
        public int status { get; set; }
        public string message { get; set; }

        public CustomResponse(int status, string message)
        {
            this.status = status;
            this.message = message;
        }
    }
}
