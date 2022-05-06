using System;
using System.ComponentModel.DataAnnotations;
namespace ConsumerService.Models
{
    public class ConsumerDetailsModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required]
        [RegularExpression("^[A-Za-z0-9]+$", ErrorMessage = "Only Numbers and Alphabets acceptable")]
        public string PanDetails { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string AgentName { get; set; }
        [Required]
        public int AgentId { get; set; }
        public BusinessDetailsModel BusinessDetails { get; set; }
    }
}
