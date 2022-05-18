using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyService.Models
{
    public class CreatePolicyModel
    {
        public string Pid { get; set; }
        public long Cid { get; set; }
    }
}
