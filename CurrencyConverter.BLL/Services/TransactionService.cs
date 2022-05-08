using CurrencyConverter.DAL.Models;
using CurrencyConverter.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.BLL.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<bool> CreateTransaction(TransactionDetails transactionDetails)
        {
            var task = _transactionRepository.CreateTransaction(transactionDetails);

            var IsSuccess = await task;

            if(!IsSuccess)
            {
                return false;
            }
            return true;
        }

        public async Task<List<TransactionDetails>> GetAllTransactions()
        {
            var task = _transactionRepository.GetAllTransactions();

            var result = await task;

            return result;
        }
        public async Task<TransactionDetails> GetTransactionById(int id)
        {
            var domainTransaction = _transactionRepository.GetTransactionById(id);

            var result = await domainTransaction;

            return result;
        }
    }
}
