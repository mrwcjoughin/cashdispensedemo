using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cashdispenseddemoxamarin.Models
{
    public interface ICashDispenseResultRepository
    {
        void Add(CashDispenseResult cashDispenseResult);
        void Update(CashDispenseResult cashDispenseResult);
        CashDispenseResult Remove(string key);
        CashDispenseResult Get(string id);
        IEnumerable<CashDispenseResult> GetAll();
    }
}
