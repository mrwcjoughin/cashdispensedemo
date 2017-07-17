using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Plugin.Connectivity;

using Models;

namespace cashdispenseddemoxamarin.Services
{
    public class CashDispenseDueCloudDataStore
    {
        private HttpClient client;
        private CashDispenseDue item;

        public CashDispenseDueCloudDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");
        }

        public async Task<CashDispenseDue> GetItemAsync()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"api/CashDispenseDue");
                try
                {
                    item = await Task.Run(() => JsonConvert.DeserializeObject<CashDispenseDue>(json));
                }
                catch(Exception ex)
                {
                    return null;
                }
            }

            return item;
        }
    }
}
