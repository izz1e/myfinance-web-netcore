using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_netcore.Models
{
    public class TransactionModel
    {
        public int? Id { get; set; }
        public string Detail { get; set; }
        public string Type { get; set;}
        public decimal Value { get; set; }
        public int FinancialRecordId { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<SelectListItem> FinancialRecords { get; set; }
    }
}