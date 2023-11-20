using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfinance_web_netcore.Domain
{
    public class Transaction
    {
        public int? Id { get; set; }
        public string Detail { get; set; }
        public string Type { get; set;}
        public decimal Value { get; set; }
        public int FinancialRecordId { get; set; }
        public DateTime Date { get; set; }
        public FinancialRecord FinancialRecord { get; set; }
    }
}