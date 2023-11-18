using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Infrastructure;

namespace myfinance_web_netcore.Services
{
    public class PlanoContaService : IPlanoContaService
    {
        MyFinanceDBContext _myFinanceDbContext;
        public PlanoContaService(MyFinanceDBContext myFinanceDBContext)
        {
            _myFinanceDbContext = myFinanceDBContext;
        }

        public IEnumerable<PlanoConta> ListarPlanoContas()
        {
            return _myFinanceDbContext.PlanoConta.ToList();
        }
    }
}