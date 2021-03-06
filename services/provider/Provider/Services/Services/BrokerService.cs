﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Models;
using Newtonsoft.Json;

namespace Services.Services
{
    public class BrokerService : IBrokerService
    {
        public static HttpClient Client { get; set; }

        public BrokerService(string brokerApiAddress)
        {
            if (string.IsNullOrWhiteSpace(brokerApiAddress))
            {
                throw new ArgumentException($"The argument {nameof(brokerApiAddress)} was null or whitespace. " +
                                            $"Please fill in the relevant sections in 'appsettings.json'. " +
                                            $"The key should be called something like {nameof(brokerApiAddress)}.");
            }

            Client = new HttpClient { BaseAddress = new Uri(brokerApiAddress) };
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> CreateSellOrderAsync(SellOrder sellOrder)
        {
            var stringObject = JsonConvert.SerializeObject(sellOrder);
            var stringContent = new StringContent(stringObject, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync("sell", stringContent);
            return response.IsSuccessStatusCode;
        }
    }
}
