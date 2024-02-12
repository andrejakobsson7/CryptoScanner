using CryptoScanner.Data.Database;
using CryptoScanner.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CryptoScanner.App.Api
{
    public class CoinApiCaller
    {
        private readonly AppDbContext context;

        public CoinApiCaller(AppDbContext context)
        {
            this.context = context;
        }

        public async Task GetAll()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://api.coingecko.com/api/v3/");

            HttpResponseMessage response = await client.GetAsync("coins/markets?vs_currency=sek&order=market_cap_desc&per_page=100&page=1&sparkline=false&locale=en");

            string responseJson = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<ApiModel>>(responseJson);
            if (result != null)
            {
                foreach (ApiModel item in result)
                {
                    CoinModel newCoin = new()
                    {
                        Name = item.Name,
                        CurrentPrice = item.CurrentPrice,
                        Image = item.Image,
                        PriceChangePercentage24H = item.PriceChangePercentage24h


                    };

                    context.Add(newCoin);

                }

                context.SaveChanges();
            }


        }
    }
}
