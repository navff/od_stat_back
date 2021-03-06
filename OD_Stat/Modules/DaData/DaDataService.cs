﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Config;
using DaData;
using Microsoft.Extensions.Configuration;
using OD_Stat.Modules.Addresses;
using OD_Stat.Modules.Geo.Addresses;

namespace OD_Stat.Modules.DaData
{
    public class DaDataService
    {
        private readonly ApiClient _apiClient;
        private IMapper _mapper;
        
        public DaDataService(IConfiguration configuration, IMapper mapper)
        {
            _mapper = mapper;
            var daDataConfig = configuration.GetSection("DaData")
                .Get<DaDataConfig>();
            _apiClient = new ApiClient(daDataConfig.Token, daDataConfig.Secret);
        }

        public async Task<List<Address>> GetAddressSuggestions(string word)
        {
            var daDataSuggestions = await _apiClient.SuggestionsQueryAddress(word);
            var result = _mapper.Map<List<Address>>(daDataSuggestions.Suggestions);
            return result;
        }
        
        public async Task<Address> GetAddressByFiasId(string word)
        {
            var daAddresses = await _apiClient.AdditionalQueryFindAddressById(word);
            var result = _mapper.Map<List<Address>>(daAddresses.Suggestions);
            return result.FirstOrDefault();
        }


    }

}