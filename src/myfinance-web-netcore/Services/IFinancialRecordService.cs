using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Services
{
    public interface IFinancialRecordService
    {
        IEnumerable<FinancialRecordModel> ListFinancialRecords();
        FinancialRecordModel ReturnRegister(int id);
        void Save(FinancialRecordModel model);
        void Delete(int id);
    }
}