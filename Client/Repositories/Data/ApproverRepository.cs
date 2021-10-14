using Client.Base.Urls;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Overtime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Repositories.Data
{
    public class UserRequestRepository : GeneralRepository<UserRequest, int>
    {
        private readonly Address address;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;

        public UserRequestRepository(Address address, string request = "UserRequests/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }
        public async Task<List<UserRequest>> GetAllUserRequest()
        {
            List<UserRequest> userRequest = new List<UserRequest>();

            using (var response = await httpClient.GetAsync(request + "UserRequests"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                userRequest = JsonConvert.DeserializeObject<List<UserRequest>>(apiResponse);
            }
            return userRequest;
        }
        public async Task<UserRequest> GetById(string id)
        {
            UserRequest entity = new UserRequest();

            using (var response = await httpClient.GetAsync(request + "UserRequests/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<UserRequest>(apiResponse);
            }
            return entity;
        }
        public String PostUserRequest(UserRequest userRequest)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(userRequest), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(request + "UserRequests", content).Result.Content.ReadAsStringAsync().Result;
            return response;
        }
    }
}
