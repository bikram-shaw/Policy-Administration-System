namespace ConsumerService.Data.Entities
{
    public class PropertyMaster
    {
        public long Id { get; set; }
        public string InsuranceType { get; set; }
        public string PropertyType { get; set; }
        public string BuildingType { get; set; }
        public long BuildingAge { get; set; }
    }
}
