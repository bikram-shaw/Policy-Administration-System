namespace AuthService.Models
{
    public class CustomResponse
    {

        public int Status { get; set; }
        public string Message { get; set; }

        public CustomResponse(int Status, string Message)
        {
            this.Status = Status;
            this.Message = Message;
        }
    }
}
