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
    public class PlanoContaService : IPlanoContaService
    {
        MyFinanceDBContext _myFinanceDbContext;
        private readonly IMapper _mapper;
        public PlanoContaService(MyFinanceDBContext myFinanceDBContext, IMapper mapper)
        {
            _myFinanceDbContext = myFinanceDBContext;
            _mapper = mapper;
        }

        public IEnumerable<PlanoContaModel> ListarPlanoContas()
        {
            var listaPlanoConta = _myFinanceDbContext.PlanoConta.ToList();
            var lista = _mapper.Map<IEnumerable<PlanoContaModel>>(listaPlanoConta);
            return lista ;
        }

        public PlanoContaModel RetornarRegistro(int id)
        {
            var item = _myFinanceDbContext.PlanoConta.Where(item => item.Id == id).First();
            return _mapper.Map<PlanoContaModel>(item);
        }

         void IPlanoContaService.Salvar(PlanoContaModel model)
        {
            var item = _mapper.Map<PlanoConta>(model);
            if (item.Id == null)
            {
                _myFinanceDbContext.PlanoConta.Add(item);
            }
            else
            {
                _myFinanceDbContext.PlanoConta.Attach(item);
                _myFinanceDbContext.Entry(item).State = EntityState.Modified;
            }
            _myFinanceDbContext.SaveChanges();
        }
   
        void IPlanoContaService.Excluir(int id)
        {
            var item = _myFinanceDbContext.PlanoConta.Where(item => item.Id == id).First();
            _myFinanceDbContext.Remove(item);
            _myFinanceDbContext.SaveChanges();
        }
    }
}