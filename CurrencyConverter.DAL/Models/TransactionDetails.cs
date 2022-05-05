using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.DAL.Models
{
    public class TransactionDetails
    {
        [Key]
        public int Id { get; set; }
        public DateTime CretationDate { get; set; }
        [MinLength(3)]
        [MaxLength(3)]
        public string CurrencyName { get; set; }
        [MinLength(3)]
        [MaxLength(3)]
        public string CurrnecyCode { get; set; }
        public decimal CurrentExchangeRate { get; set; }
        public decimal GivenAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public string Status { get; set; }
    }
}
