using System.Collections.Generic;

namespace ConsumerService.Data.Entities
{
    public class BusinessDetails
    {
        public long Id { get; set; }
        public string BusinessCategory { get; set; }
        public string BusinessType { get; set; }
        public long BusinessTurnOver { get; set; }
        public long CapitalInvested { get; set; }
        public long TotalEmployee { get; set; }
        public long BusinessValue { get; set; }
        public long BusinessAge { get; set; }

        public long ConsumerId { get; set; }
        public ConsumerDetails ConsumerDetails { get; set; }
       
        public List<PropertyDetails> Properties { get; set; }
    }
}
