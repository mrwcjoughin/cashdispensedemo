using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using cashdispenseddemoxamarin.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace cashdispenseddemoxamarin
{
    public class CashDispenseResultCloudDataStore : IDataStore<CashDispenseResult>
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
                var json = await client.GetStringAsync($"api/CashDispenseResult");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<CashDispenseResult>>(json));
            }

            return items;
        }

        public async Task<CashDispenseResult> GetItemAsync(string id)
        {
            if (id != null && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"api/CashDispenseResult/{id}");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<CashDispenseResult>>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(CashDispenseResult item)
        {
            if (item == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/CashDispenseResult", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode ? true : false;
        }

        public async Task<bool> UpdateItemAsync(CashDispenseResult item)
        {
            if (item == null || item.Id == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            var buffer = System.Text.Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"api/CashDispenseResult/{item.Id}"), byteContent);

            return response.IsSuccessStatusCode ? true : false;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !CrossConnectivity.Current.IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/CashDispenseResult/{id}");

            return response.IsSuccessStatusCode ? true : false;
        }
    }
}
