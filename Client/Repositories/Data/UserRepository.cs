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
        public UserRepository(Address address, string request) : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }
        public string Register(RegisterVM registerVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(registerVM), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(request + "Register", content).Result.Content.ReadAsStringAsync().Result;

            return response;
        }
    }
}
