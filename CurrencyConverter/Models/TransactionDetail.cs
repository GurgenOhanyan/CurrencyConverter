using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Models
{
    public class TransactionDetail
    {
        public int Id { get; set; }
        public DateTime CretationDate { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public decimal GivenAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public string Status { get; set; }
    }
}
