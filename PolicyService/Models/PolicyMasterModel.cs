namespace PolicyService.Models
{
    public class PolicyMasterModel
    {
		public string Id { get; set; }
		public string PropertyType { get; set; }
		public string ConsumerType { get; set; }
		public double AssuredSum { get; set; }
		public string Tenure { get; set; }
		public long BusinessValue { get; set; }
		public long PropertyValue { get; set; }
		public string BaseLocation { get; set; }
		public string Type { get; set; }
	}
}
