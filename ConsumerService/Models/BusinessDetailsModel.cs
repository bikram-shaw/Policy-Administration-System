using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ConsumerService.Models
{
    public class BusinessDetailsModel
    {
        public long Id { get; set; }
        [Required]
        public string BusinessCategory { get; set; }
        [Required]
        public string BusinessType { get; set; }
        [Required]
        public long BusinessTurnOver { get; set; }
        [Required]
        public long CapitalInvested { get; set; }
        [Required]
        public long TotalEmployee { get; set; }
        [Required]
       
        public long BusinessValue { get; set; }
        [Required]
        public long BusinessAge { get; set; }

        public List<PropertyDetailsModel> PropertyDetails { get; set; }
       
    }
}
