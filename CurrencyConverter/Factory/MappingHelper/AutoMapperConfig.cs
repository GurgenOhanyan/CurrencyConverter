using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Factory.MappingHelper
{
    public static class AutoMapperConfig
    {
        private static Mapper _mapper;
        public static Mapper CreateInstance()
        {
            if (_mapper == null)
            {
                Register();
            }
            return _mapper;
        }
        private static void Register()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<Models.TransactionDetail,DAL.Models.TransactionDetails>();
                config.CreateMap<DAL.Models.TransactionDetails, Models.TransactionDetail>();
            });
            _mapper = new Mapper(config);
        }
    }
}
