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
    public class FinancialRecordService : IFinancialRecordService
    {
        MyFinanceDBContext _myFinanceDbContext;
        private readonly IMapper _mapper;
        public FinancialRecordService(MyFinanceDBContext myFinanceDBContext, IMapper mapper)
        {
            _myFinanceDbContext = myFinanceDBContext;
            _mapper = mapper;
        }

        public IEnumerable<FinancialRecordModel> ListFinancialRecords()
        {
            var listaFinancialRecord = _myFinanceDbContext.FinancialRecord.ToList();
            var lista = _mapper.Map<IEnumerable<FinancialRecordModel>>(listaFinancialRecord);
            return lista ;
        }

        public FinancialRecordModel ReturnRegister(int id)
        {
            var item = _myFinanceDbContext.FinancialRecord.Where(item => item.Id == id).First();
            return _mapper.Map<FinancialRecordModel>(item);
        }

         void IFinancialRecordService.Save(FinancialRecordModel model)
        {
            var item = _mapper.Map<FinancialRecord>(model);
            if (item.Id == null)
            {
                _myFinanceDbContext.FinancialRecord.Add(item);
            }
            else
            {
                _myFinanceDbContext.FinancialRecord.Attach(item);
                _myFinanceDbContext.Entry(item).State = EntityState.Modified;
            }
            _myFinanceDbContext.SaveChanges();
        }
   
        void IFinancialRecordService.Delete(int id)
        {
            var item = _myFinanceDbContext.FinancialRecord.Where(item => item.Id == id).First();
            _myFinanceDbContext.Remove(item);
            _myFinanceDbContext.SaveChanges();
        }
    }
}