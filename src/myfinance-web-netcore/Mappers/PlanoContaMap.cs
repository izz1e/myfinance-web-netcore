using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace myfinance_web_netcore.Mappers
{
    public class PlanoContaMap : Profile
    {
        public PlanoContaMap(){
            CreateMap<Domain.PlanoConta, Models.PlanoContaModel>().ReverseMap();
        }
    }
}