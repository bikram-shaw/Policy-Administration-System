using System;

namespace ConsumerService.Data.Entities
{
    public class ConsumerDetails
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string PanDetails { get; set; }
        public string Phone { get; set; }
        public string AgentName { get; set; }
        public int AgentId { get; set; }

        public  BusinessDetails BusinessDetails { get; set; }

    }
}
