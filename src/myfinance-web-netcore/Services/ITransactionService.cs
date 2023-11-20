using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Services
{
    public interface ITransactionService
    {
        IEnumerable<TransactionModel> ListTransactions();
        TransactionModel ReturnRegister(int id);
        void Save(TransactionModel model);
        void Delete(int id);
    }
}