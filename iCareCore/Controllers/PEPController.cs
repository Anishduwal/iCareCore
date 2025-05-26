using iCareCore.Core.Entities.RequestDTOs;
using iCareCore.Core.Entities.ResponseDTOs;
using iCareCore.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace iCareCore.API.Controllers
{
    public class PEPController : Controller
    {
        private readonly IDBANService _service;
        public PEPController(IDBANService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("DEBAConnect")]
        public async Task<List<ListData>> DEBAConnect(EnquiryRequest enquiryRequest)
        {
            DBANLoginResponse loginResponse = await _service.Login();
            DBANEnquiryResponse response = new();
            if (loginResponse.status)
            {
                string token = loginResponse.data.token;
                response = await _service.GetData(enquiryRequest, token);
                var result = new List<ListData>();
                foreach (var item in response.data.pep.data)
                {
                    string remarks = string.Empty;
                    remarks = "Father Name = " + item.father_name + "</br> Mother Name ="+ item.mother_name + "</br> Spouse Name =" + item.spouse_name + "</br> Citizenship No =" + item.citizenship_number;
                    result = response.data.pep.data.Select(x => new ListData
                    {
                        MATCH_NAME = x.name,
                        MATCHED_ID = x.id.ToString(),
                        REMARKS = remarks,
                        DOB = x.dob,
                        source = x.pep_category.name
                    }).ToList();
                }
                return result;
            }
            return new List<ListData>();
        }
    }
}
