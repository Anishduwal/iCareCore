using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCareCore.Core.Entities.ResponseDTOs
{
    public class DBANLoginResponse
    {
        public bool status { get; set; }
        public Int64 code { get; set; }
        public string message { get; set; }
        public Token data { get; set; }
    }
    public class Token
    {
        public string token { get; set; }
    }
}
