using Client.Base.Urls;
using Newtonsoft.Json;
using Overtime.Models;
using Overtime.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Repositories.Data
{
    public class RequestRepository: GeneralRepository<Request, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;

        public RequestRepository(Address address, string request = "Requests/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }
        public HttpStatusCode Approve(UpdateStatusVM updateStatusVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(updateStatusVM), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync(request + "Approve", content).Result;
            return result.StatusCode;
        }

        public HttpStatusCode Process(UpdateStatusVM updateStatusVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(updateStatusVM), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync(request + "Process", content).Result;
            return result.StatusCode;
        }

        public HttpStatusCode Decline(UpdateStatusVM updateStatusVM)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(updateStatusVM), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync(request + "Decline", content).Result;
            return result.StatusCode;
        }
        public HttpStatusCode DeleteReq(int id)
        {
            var result = httpClient.DeleteAsync(request + id).Result;
            return result.StatusCode;
        }
    }
}
