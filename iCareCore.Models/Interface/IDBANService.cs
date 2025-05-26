using iCareCore.Core.Entities.RequestDTOs;
using iCareCore.Core.Entities.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace iCareCore.Core.Interface
{
    public interface IDBANService
    {
        Task<DBANLoginResponse> Login();
        Task<DBANEnquiryResponse> GetData(EnquiryRequest enquiryRequest, string token);
    }
}
