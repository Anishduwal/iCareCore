using iCareCore.Core.IRepo;
using iCareCore.Core.Entities.RequestDTOs;
using iCareCore.Core.Entities.ResponseDTOs;
using iCareCore.Core.Interface;
using iCareCore.Infrastructure.DbHelper;
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
            login.username = DbConn.DBANUsername;
            login.password = DbConn.DBANPassword;
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
                            if (responseStr != null || responseStr != string.Empty)
                            {
                                apiresp = JsonSerializer.Deserialize<DBANLoginResponse>(responseStr);
                            }
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
            string jsonstr = string.Empty;
            if (enquiryRequest.name != "" || enquiryRequest.father_name != "" || enquiryRequest.mother_name != "")
            {
                jsonstr = JsonSerializer.Serialize(enquiryRequest);
            }
            else
            {
                apiresp = new DBANEnquiryResponse()
                {
                    code = 400,
                    message = "Please provide any name here"
                };
                return apiresp;
            }

            try
            {
                using (var client = new HttpClient())
                {
                    if (token != string.Empty)
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
                    else
                    {
                        apiresp = new DBANEnquiryResponse()
                        {
                            code = 400,
                            message = "Token is empty"
                        };
                        return apiresp;
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
