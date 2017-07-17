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
    public class UserCloudDataStore : IDataStore<User>
    {
        HttpClient client;
        IEnumerable<User> items;

        public UserCloudDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");

            items = new List<User>();
        }

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"api/User");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<User>>(json));
            }

            return items;
        }

        public async Task<User> GetItemAsync(string id)
        {
            if (id != null && CrossConnectivity.Current.IsConnected)
            {
                var json = await client.GetStringAsync($"api/User/{id}");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<User>>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(User item)
        {
            if (item == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/User", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode ? true : false;
        }

        public async Task<bool> UpdateItemAsync(User item)
        {
            if (item == null || item.Id == null || !CrossConnectivity.Current.IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            var buffer = System.Text.Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync($"api/User/{item.Id}", byteContent);

            return response.IsSuccessStatusCode ? true : false;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !CrossConnectivity.Current.IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/User/{id}");

            return response.IsSuccessStatusCode ? true : false;
        }

		public async Task<string> LoginAsync(User user)
		{
			if (user == null || user.UserName == null || !CrossConnectivity.Current.IsConnected)
				return string.Empty;
            
            var jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.Formatting = Formatting.Indented;
            jsonSerializerSettings.TypeNameHandling = TypeNameHandling.All;
			var serializedItem = JsonConvert.SerializeObject(user, user.GetType(), jsonSerializerSettings);

            var stringContent = new StringContent(serializedItem, Encoding.UTF8, "application/json");

			var response = await client.PostAsync($"api/User", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return string.Empty;
            }
		}
    }
}
