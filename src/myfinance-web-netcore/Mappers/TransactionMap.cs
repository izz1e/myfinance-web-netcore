using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace myfinance_web_netcore.Mappers
{
    public class TransactionMap : Profile
    {
        public TransactionMap(){
            CreateMap<Domain.Transaction, Models.TransactionModel>().ReverseMap();
        }
    }
}