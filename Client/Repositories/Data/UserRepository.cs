using Client.Base.Urls;
using Newtonsoft.Json;
using Overtime.Models;
using Overtime.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Repositories.Data
{
    public class UserRepository : GeneralRepository<User, string>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        public UserRepository(Address address, string request = "Users/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

        public async Task<List<RegisterVM>> GetAllProfile()
        {
            List<RegisterVM> registers = new List<RegisterVM>();

            using (var response = await httpClient.GetAsync(request + "GetAllProfile"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                registers = JsonConvert.DeserializeObject<List<RegisterVM>>(apiResponse);
            }
            return registers;
        }

        public async Task<RegisterVM> GetById(string userId)
        {
            RegisterVM register = new RegisterVM();

            using (var response = await httpClient.GetAsync(request + "GetById/" + userId))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                register = JsonConvert.DeserializeObject<RegisterVM>(apiResponse);
            }
            return register;
        }

        public string Register(RegisterVM registerVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(registerVM), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(request + "Register", content).Result.Content.ReadAsStringAsync().Result;

            return response;
        }
    }
}
