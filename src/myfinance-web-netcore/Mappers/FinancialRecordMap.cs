using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace myfinance_web_netcore.Mappers
{
    public class FinancialRecordMap : Profile
    {
        public FinancialRecordMap(){
            CreateMap<Domain.FinancialRecord, Models.FinancialRecordModel>().ReverseMap();
        }
    }
}