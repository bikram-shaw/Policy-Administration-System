namespace PolicyService.Data.Entities
{
    public class ConsumerPolicy
    {

		
	    public long Id { get; set; }
		public string Pid { get; set; }
		public long ConsumerId { get; set; }
		public string PropertyType { get; set; }
		public string ConsumerType { get; set; }
		public string AssuredSum { get; set; }
		public string Tenure { get; set; }
		public long BusinessValue { get; set; }
		public long PropertyValue { get; set; }
		public string BaseLocation { get; set; }
		public string Type { get; set; }
		public string AcceptedQuote { get; set; }
		public string Status { get; set; }
	}
}
