using CurrencyConverter.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.BLL.Services
{
    public interface ITransactionService
    {
        Task<List<TransactionDetails>> GetAllTransactions();
        Task<TransactionDetails> GetTransactionById(int id);
        Task<bool> CreateTransaction(TransactionDetails transactionDetails);
    }
}
