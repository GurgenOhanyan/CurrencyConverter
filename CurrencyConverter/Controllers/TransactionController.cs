using CurrencyConverter.BLL.Services;
using CurrencyConverter.Factory;
using CurrencyConverter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyConverter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionFactory _transactionFactory;

        public TransactionController(ITransactionFactory transactionFactory)
        {
            _transactionFactory = transactionFactory;
        }
        [HttpGet("GetAllTransaction")]
        public async Task<List<TransactionDetail>> GetAllTransactions()
        {
            return await _transactionFactory.GetAllTransactions();
        }
        [HttpPost("DoTransaction")]
        public async Task<ActionResult<string>> CreateTransaction(string CurrencyName, decimal amount)
        {
            if (CurrencyName.Length != 3)
            {
                return BadRequest("Invalid Currency Name");
            }

            string result = await _transactionFactory.CreateTransaction(CurrencyName, amount);

            if (result == "Invalid Currency Name"|| result == "Transaction Failed")
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("GetTransactionById")]
        public async Task<ActionResult> GetTransactionById(int Id)
        {
            var trasnsaction = await _transactionFactory.GetTransactionById(Id);

            if (trasnsaction==null)
            {
                return BadRequest($"Transaction With {Id} IDs Not Found");
            }

            return Ok(trasnsaction);
        }
    }
}
