using CurrencyConverter.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.DAL.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ConverterDbContext _converterDbContext;
        public TransactionRepository(ConverterDbContext converterDbContext)
        {
            _converterDbContext = converterDbContext;
        }
        public async Task<bool> CreateTransaction(TransactionDetails transactionDetails)
        {
            try
            {
                await _converterDbContext.TransactionDetails.AddAsync(transactionDetails);

                await _converterDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                transactionDetails.Status = "Failed";
                await _converterDbContext.TransactionDetails.AddAsync(transactionDetails);
                await _converterDbContext.SaveChangesAsync();
                return false;
            }
            return true;
        }
        public async Task<List<TransactionDetails>> GetAllTransactions()
        {
            var task = _converterDbContext.TransactionDetails.ToListAsync();
            var transactions = await task;
            return transactions;
        }
        public async Task<TransactionDetails> GetTransactionById(int id)
        {
            var transaction = _converterDbContext.TransactionDetails.Where(t => t.Id == id).FirstOrDefaultAsync();
            return await transaction;
        }
    }
}
