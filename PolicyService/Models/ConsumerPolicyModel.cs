using System.ComponentModel.DataAnnotations;

namespace PolicyService.Models
{
    public class ConsumerPolicyModel
    {
		
		public long Id { get; set; }
		[Required]
		public string Pid { get; set; }
		
		[Required]
		public string PropertyType { get; set; }
		[Required]
		public string ConsumerType { get; set; }
		[Required]
		public string AssuredSum { get; set; }
		[Required]
		public string Tenure { get; set; }
		[Required]
		public long BusinessValue { get; set; }
		[Required]
		public long PropertyValue { get; set; }
		[Required]
		public string BaseLocation { get; set; }
		[Required]
		public string Type { get; set; }
		[Required]
		public string AcceptedQuote { get; set; }
		public string Status { get; set; }
		[Required]
		public long ConsumerId { get; set; }
	}
}
