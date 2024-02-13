using CryptoScanner.Data.Database;
using CryptoScanner.Data.Models;
using Newtonsoft.Json;

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

            //comment

        }

        public void PopulateList()
        {
            var tenCoins = context.Coins.OrderBy(CoinModel => CoinModel.CurrentPrice).Take(10);
            foreach (var coin in tenCoins)
            {
                CoinManager.CoinManager.coinList.Add(coin);
            }
        }

        public void AddToCoinList(CoinModel coinToAdd)
        {
            if (coinToAdd == null)
            {
                CoinManager.CoinManager.coinList.Add(coinToAdd);
            }
        }

        public void SortByAscending()
        {
            CoinManager.CoinManager.coinList.OrderBy(CoinModel => CoinModel.CurrentPrice);
        }

        public void SortByDescending()
        {
            CoinManager.CoinManager.coinList.OrderByDescending(CoinModel => CoinModel.CurrentPrice);
        }
    }
}
