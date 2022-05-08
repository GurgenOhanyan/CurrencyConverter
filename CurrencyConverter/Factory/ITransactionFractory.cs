using CurrencyConverter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Factory
{
    public interface ITransactionFactory
    {
        Task<List<TransactionDetail>> GetAllTransactions();
        Task<TransactionDetail> GetTransactionById(int id);
        Task<string> CreateTransaction(string currencyName,decimal amount);
    }
}
