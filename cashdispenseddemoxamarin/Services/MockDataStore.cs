using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace cashdispenseddemoxamarin.Services
{
    public class MockDataStore : IDataStore<CashDispenseResult>
    {
        bool isInitialized;
        List<CashDispenseResult> items;

        public MockDataStore()
        {
            items = new List<CashDispenseResult>();
            var _items = new List<CashDispenseResult>
            {
            };

            foreach (CashDispenseResult item in _items)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(CashDispenseResult item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(CashDispenseResult item)
        {
            var _item = items.Where((CashDispenseResult arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((CashDispenseResult arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<CashDispenseResult> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<CashDispenseResult>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
