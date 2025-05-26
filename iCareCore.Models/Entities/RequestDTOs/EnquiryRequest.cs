using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCareCore.Core.Entities.RequestDTOs
{
    public class EnquiryRequest
    {
        public string? name { get; set; }
        public string? father_name { get; set; }
        public string? mother_name { get; set; }
        public string? spouse_name { get; set; }
    }
}
