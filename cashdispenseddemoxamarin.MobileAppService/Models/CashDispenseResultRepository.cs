using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class CashDispenseResultRepository : ICashDispenseResultRepository
    {
        private static ConcurrentDictionary<string, CashDispenseResult> _CashDispenseResults =
            new ConcurrentDictionary<string, CashDispenseResult>();

        public CashDispenseResultRepository()
        {
        }

        public CashDispenseResult Get(string id)
        {
            return _CashDispenseResults[id];
        }

        public IEnumerable<CashDispenseResult> GetAll()
        {
            return _CashDispenseResults.Values;
        }

        public void Add(CashDispenseResult CashDispenseResult)
        {
            CashDispenseResult.Id = Guid.NewGuid().ToString();
            _CashDispenseResults[CashDispenseResult.Id] = CashDispenseResult;
        }

        public CashDispenseResult Find(string id)
        {
            CashDispenseResult CashDispenseResult;
            _CashDispenseResults.TryGetValue(id, out CashDispenseResult);

            return CashDispenseResult;
        }

        public CashDispenseResult Remove(string id)
        {
            CashDispenseResult CashDispenseResult;
            _CashDispenseResults.TryRemove(id, out CashDispenseResult);

            return CashDispenseResult;
        }

        public void Update(CashDispenseResult CashDispenseResult)
        {
            _CashDispenseResults[CashDispenseResult.Id] = CashDispenseResult;
        }
    }
}
