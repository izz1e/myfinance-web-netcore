using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace myfinance_web_netcore.Mappers
{
    public class TransacaoMap : Profile
    {
        public TransacaoMap(){
            CreateMap<Domain.Transacao, Models.TransacaoModel>().ReverseMap();
        }
    }
}