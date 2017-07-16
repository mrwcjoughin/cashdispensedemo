//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json;
//using Plugin.Connectivity;

//using cashdispenseddemoxamarin.Models;

//namespace cashdispenseddemoxamarin.Services
//{
//    public class CashDispenseDueCloudDataStore //: IDataStore<CashDispenseDue>
//    {
//        HttpClient client;
//        IEnumerable<cashdispenseddemoxamarin.Models.CashDispenseDue> items;

//        public CashDispenseDueCloudDataStore()
//        {
//            client = new HttpClient();
//            //client.BaseAddress = new Uri($"{App.BackendUrl}/");

//            items = new List<CashDispenseDue>();
//        }

//        public async Task<IEnumerable<CashDispenseDue>> GetItemsAsync(bool forceRefresh = false)
//        {
//            if (forceRefresh && CrossConnectivity.Current.IsConnected)
//            {
//                var json = await client.GetStringAsync($"api/CashDispenseDue");
//                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<CashDispenseDue>>(json));
//            }

//            return items;
//        }

//        public async Task<CashDispenseResult> GetItemAsync(string id)
//        {
//            if (id != null && CrossConnectivity.Current.IsConnected)
//            {
//                var json = await client.GetStringAsync($"api/CashDispenseDue/{id}");
//                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<CashDispenseDue>>(json));
//            }

//            return null;
//        }

//        public async Task<bool> AddItemAsync(CashDispenseDue item)
//        {
//            if (item == null || !CrossConnectivity.Current.IsConnected)
//                return false;

//            var serializedItem = JsonConvert.SerializeObject(item);

//            var response = await client.PostAsync($"api/CashDispenseDue", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

//            return response.IsSuccessStatusCode ? true : false;
//        }

//        public async Task<bool> UpdateItemAsync(CashDispenseDue item)
//        {
//            if (item == null || item.Id == null || !CrossConnectivity.Current.IsConnected)
//                return false;

//            var serializedItem = JsonConvert.SerializeObject(item);
//            var buffer = System.Text.Encoding.UTF8.GetBytes(serializedItem);
//            var byteContent = new ByteArrayContent(buffer);

//            var response = await client.PutAsync(new Uri($"api/CashDispenseDue/{item.Id}"), byteContent);

//            return response.IsSuccessStatusCode ? true : false;
//        }

//        public async Task<bool> DeleteItemAsync(string id)
//        {
//            if (string.IsNullOrEmpty(id) && !CrossConnectivity.Current.IsConnected)
//                return false;

//            var response = await client.DeleteAsync($"api/CashDispenseDue/{id}");

//            return response.IsSuccessStatusCode ? true : false;
//        }
//    }
//}
