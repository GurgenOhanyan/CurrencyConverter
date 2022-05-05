using CurrencyConverter.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.DAL.Repositories
{
   
    public interface ITransactionRepository
    {
        Task<List<TransactionDetails>> GetAllTransactions();
        Task<TransactionDetails> GetTransactionById(int id);
        Task<decimal> GetGivenExchangeRate(); 
    }
}
