namespace ConsumerService.Data.Entities
{
    public class PropertyDetails
    {
        public long Id { get; set; }
		public string PropertyType { get; set; }
		public string BuildingSqft { get; set; }
		public string BuildingType { get; set; }
		public string BuildingStoreys { get; set; }
		public long BuildingAge { get; set; }
		public long PropertyValue { get; set; }
		public long CostoftheAsset { get; set; }
		public long UseFulLifeOfTheAsset { get; set; }
		public long SalvageValue { get; set; }

		public long BusinessId { get; set; }
		public BusinessDetails BusinessDetails { get; set; }
	}
}
