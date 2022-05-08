using CurrencyConverter.BLL.Services;
using CurrencyConverter.Factory.MappingHelper;
using CurrencyConverter.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CurrencyConverter.Factory
{
    public class TransactionFactory : ITransactionFactory
    {
        private readonly ITransactionService _transactionService;
        
        public TransactionFactory(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        public async Task<string> CreateTransaction(string currencyName,decimal amount)
        {
            string exchangeRates;
            decimal currentCurrencyRate = default;
            decimal rateToamd = default;
            TransactionDetail transactionDetail = new TransactionDetail();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {

                    httpClient.DefaultRequestHeaders.Add("apikey", "vbjeljWWPNFs5FGuVoXeefSI6jdplMS1");

                    exchangeRates = await httpClient.GetStringAsync("https://api.apilayer.com/exchangerates_data/latest");

                    currentCurrencyRate = Convert.ToDecimal(JObject.Parse(JObject.Parse(exchangeRates)["rates"].ToString())[currencyName].ToString());

                    rateToamd = Convert.ToDecimal(JObject.Parse(JObject.Parse(exchangeRates)["rates"].ToString())["AMD"].ToString());

                    transactionDetail.CretationDate = DateTime.Now;
                    transactionDetail.CurrencyName = currencyName;
                    transactionDetail.GivenAmount = amount;
                    transactionDetail.ReceivedAmount = amount * rateToamd / currentCurrencyRate;
                    transactionDetail.Status = "Successful";

                    switch (currencyName)
                    {
                        case "USD":
                            transactionDetail.CurrencyCode = "001";
                            break;
                        case "EUR":
                            transactionDetail.CurrencyCode = "049";
                            break;
                        case "RUB":
                            transactionDetail.CurrencyCode = "058";
                            break;
                    }

                }

            }
            catch (NullReferenceException ex)
            {
                return "Invalid Currency Name";
            }

      

            var task = _transactionService.CreateTransaction(MapperExtension.MapTo<DAL.Models.TransactionDetails>(transactionDetail));

            var isSuccess = await task;

            if (!isSuccess)
            {
                return "Transaction Failed";
            }

            return "Transactoin Successfuly";
        }

        public async Task<List<TransactionDetail>> GetAllTransactions()
        {
            var task = _transactionService.GetAllTransactions();

            var domainModels = await task;

            return domainModels.Select(domModel => MapperExtension.MapTo<TransactionDetail>(domModel)).ToList();
        }
        public async Task<TransactionDetail> GetTransactionById(int id)
        {
            var task = _transactionService.GetTransactionById(id);
            var domainModel = await task;
            return MapperExtension.MapTo<TransactionDetail>(domainModel);
        }
    }
}
