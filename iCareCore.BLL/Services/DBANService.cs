using iCareCore.Core.IRepo;
using iCareCore.Core.Entities.RequestDTOs;
using iCareCore.Core.Entities.ResponseDTOs;
using iCareCore.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace iCareCore.Application.Services
{
    public class DBANService : IDBANService
    {
        public async Task<DBANLoginResponse> Login()
        {
            DBANLoginResponse apiresp = new();
            string url = "https://peps.dban.com.np/api/thirdparty/";
            DBANLogin login = new();
            login.username = "test";
            login.password = "Test@123";
            string jsonstr = JsonSerializer.Serialize(login);
            try
            {
                using (var client = new HttpClient())
                {
                    var content = new StringContent(jsonstr, Encoding.UTF8, "application/json");
                    using (var http_response = await client.PostAsync(url + "login", content))
                    {
                        if (http_response.IsSuccessStatusCode)
                        {
                            string responseStr = await http_response.Content.ReadAsStringAsync();
                            apiresp = JsonSerializer.Deserialize<DBANLoginResponse>(responseStr);
                            return apiresp;
                        }
                        else
                        {
                            apiresp = new DBANLoginResponse()
                            {
                                code = 400,
                                message = "Something went wrong"
                            };

                            return apiresp;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                apiresp.message = ex.Message;
                return apiresp;
            }
        }

        public async Task<DBANEnquiryResponse> GetData(EnquiryRequest enquiryRequest, string token)
        {
            DBANEnquiryResponse apiresp = new();
            string url = "https://peps.dban.com.np/api/thirdparty/";
            string jsonstr = JsonSerializer.Serialize(enquiryRequest);

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var content = new StringContent(jsonstr, Encoding.UTF8, "application/json");
                    using (var http_response = await client.PostAsync(url + "pep/enquiry", content))
                    {
                        if (http_response.IsSuccessStatusCode)
                        {
                            string responseStr = await http_response.Content.ReadAsStringAsync();
                            DBANEnquiryResponse response = JsonSerializer.Deserialize<DBANEnquiryResponse>(responseStr);
                            return response;
                        }
                        else
                        {
                            string responseStr = await http_response.Content.ReadAsStringAsync();
                            apiresp = new DBANEnquiryResponse()
                            {
                                code = 400,
                                message = responseStr
                            };

                            return apiresp;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                apiresp.message = ex.Message;
                return apiresp;
            }
        }
    }
}
