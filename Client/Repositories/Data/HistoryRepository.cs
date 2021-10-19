using Client.Base.Urls;
using Newtonsoft.Json;
using Overtime.Models;
using Overtime.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Repositories.Data
{
    public class HistoryRepository : GeneralRepository<Request, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        public HistoryRepository(Address address, string request = "Requests/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

        public async Task<List<ApproverListVM>> GetHistory()
        {
            List<ApproverListVM> historyList = new List<ApproverListVM>();

            using (var response = await httpClient.GetAsync(request + "GetAllHistory"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                historyList = JsonConvert.DeserializeObject<List<ApproverListVM>>(apiResponse);
            }
            return historyList;
        }
    }
}
