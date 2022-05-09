using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyService.Models
{
    public class CustomResponse
    {

        public int statuscode { get; set; }
        public string message { get; set; }
        public object data { get; set; }

        public CustomResponse(int statuscode, string message, object data)
        {
            this.statuscode = statuscode;
            this.message = message;
            this.data = data;
        }
    }
}
