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
    public class CashDispenseResultCloudDataStore
    {
        HttpClient client;
        IEnumerable<CashDispenseResult> items;

        public CashDispenseResultCloudDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");

            items = new List<CashDispenseResult>();
        }

        public async Task<IEnumerable<CashDispenseResult>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    var json = await client.GetStringAsync($"api/CashDispenseResult");
                    items = JsonConvert.DeserializeObject<IEnumerable<CashDispenseResult>>(json);
                }
                catch(Exception ex)
                {
                    System.Console.WriteLine(ex.ToString());
                }
            }

            return items;
        }

        public async Task<bool> AddItemAsync(CashDispenseResult item)
        {
            if (item == null || !CrossConnectivity.Current.IsConnected)
                return false;

            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.ObjectCreationHandling = ObjectCreationHandling.Replace;
            jsonSerializerSettings.TypeNameHandling = TypeNameHandling.All;
            jsonSerializerSettings.TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple;
            jsonSerializerSettings.Formatting = Formatting.Indented;

            jsonSerializerSettings.FloatFormatHandling = FloatFormatHandling.String;

            var serializedItem = JsonConvert.SerializeObject(item, item.GetType(), jsonSerializerSettings);

            var response = await client.PostAsync($"api/CashDispenseResult", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode ? true : false;
        }
    }
}