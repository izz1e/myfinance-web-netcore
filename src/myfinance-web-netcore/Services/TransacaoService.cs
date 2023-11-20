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
    public class TransacaoService : ITransacaoService
    {
        MyFinanceDBContext _myFinanceDbContext;
        private readonly IMapper _mapper;
        public TransacaoService(MyFinanceDBContext myFinanceDBContext, IMapper mapper)
        {
            _myFinanceDbContext = myFinanceDBContext;
            _mapper = mapper;
        }

        public IEnumerable<TransacaoModel> ListarTransacoes()
        {
            var listaTransacao = _myFinanceDbContext.Transacao.ToList();
            var lista = _mapper.Map<IEnumerable<TransacaoModel>>(listaTransacao);
            return lista ;
        }

        public TransacaoModel RetornarRegistro(int id)
        {
            var item = _myFinanceDbContext.Transacao.Where(item => item.Id == id).First();
            return _mapper.Map<TransacaoModel>(item);
        }

         void ITransacaoService.Salvar(TransacaoModel model)
        {
            var item = _mapper.Map<Transacao>(model);
            if (item.Id == null)
            {
                _myFinanceDbContext.Transacao.Add(item);
            }
            else
            {
                _myFinanceDbContext.Transacao.Attach(item);
                _myFinanceDbContext.Entry(item).State = EntityState.Modified;
            }
            _myFinanceDbContext.SaveChanges();
        }
   
        void ITransacaoService.Excluir(int id)
        {
            var item = _myFinanceDbContext.Transacao.Where(item => item.Id == id).First();
            _myFinanceDbContext.Remove(item);
            _myFinanceDbContext.SaveChanges();
        }
    }
}