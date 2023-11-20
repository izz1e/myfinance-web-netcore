using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Infrastructure;
using myfinance_web_netcore.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace myfinance_web_netcore.Services
{
    public class TransactionService : ITransactionService
    {
        MyFinanceDBContext _myFinanceDbContext;
        private readonly IMapper _mapper;
        private readonly IFinancialRecordService _financialPlanService;
        public TransactionService(MyFinanceDBContext myFinanceDBContext, IMapper mapper, IFinancialRecordService financialPlanService)
        {
            _myFinanceDbContext = myFinanceDBContext;
            _mapper = mapper;
            _financialPlanService = financialPlanService;
        }

        public IEnumerable<TransactionModel> ListTransactions()
        {
            var listaTransaction = _myFinanceDbContext.Transaction.ToList();
            var lista = _mapper.Map<IEnumerable<TransactionModel>>(listaTransaction);
            return lista ;
        }

        public TransactionModel ReturnRegister(int id)
        {
            var item = _myFinanceDbContext.Transaction.Where(item => item.Id == id).First();
            return _mapper.Map<TransactionModel>(item);
        }

         void ITransactionService.Save(TransactionModel model)
        {
            var item = _mapper.Map<Transaction>(model);
            item.Type = _financialPlanService.ReturnRegister(model.FinancialRecordId).Type;
            
            if (item.Id == null)
            {
                _myFinanceDbContext.Transaction.Add(item);
            }
            else
            {
                _myFinanceDbContext.Transaction.Attach(item);
                _myFinanceDbContext.Entry(item).State = EntityState.Modified;
            }
            _myFinanceDbContext.SaveChanges();
        }
   
        void ITransactionService.Delete(int id)
        {
            var item = _myFinanceDbContext.Transaction.Where(item => item.Id == id).First();
            _myFinanceDbContext.Remove(item);
            _myFinanceDbContext.SaveChanges();
        }
    }
}