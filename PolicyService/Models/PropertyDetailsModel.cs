using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PolicyService.Models
{
    public class PropertyDetailsModel
    {
        public long Id { get; set; }
        [Required]
        public string PropertyType { get; set; }
        [Required]
        public string BuildingSqft { get; set; }
        [Required]
        public string BuildingType { get; set; }
        [Required]
        public string BuildingStoreys { get; set; }
        [Required]
        public long BuildingAge { get; set; }
        [Required]
        [JsonIgnore]
        public long PropertyValue { get; set; }
        [Required]
        public long CostoftheAsset { get; set; }
        [Required]
        public long UseFulLifeOfTheAsset { get; set; }
        [Required]
        public long SalvageValue { get; set; }
        [Required]
        public long BusinessId { get; set; }



    }
}
