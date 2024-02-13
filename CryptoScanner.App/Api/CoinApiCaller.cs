using CryptoScanner.Data.Database;
using CryptoScanner.Data.Models;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;

namespace CryptoScanner.App.Api
{
    public class CoinApiCaller
    {
        private readonly AppDbContext context;
        internal HttpClient Client { get; set; }

        public CoinApiCaller(AppDbContext context)
        {
            this.context = context;
            Client = new HttpClient();
        }

        public async Task GetAll()
        {


            Client.BaseAddress = new Uri("https://api.coingecko.com/api/v3/");

            HttpResponseMessage response = await Client.GetAsync("coins/list");

            string responseJson = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<ApiModel>>(responseJson);


            //if (result != null)
            //{
            //    foreach (ApiModel item in result)
            //    {
            //        CoinModel newCoin = new()
            //        {
            //            Name = item.Name,
            //            CurrentPrice = item.CurrentPrice,
            //            Image = item.Image,
            //            PriceChangePercentage24H = item.PriceChangePercentage24h


            //        };

            //        context.Add(newCoin);

            //    }

            //    context.SaveChanges();
            //}

            //comment

        }

        public async Task<CoinModel> MakeCall(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }


            HttpResponseMessage response = await Client.GetAsync("coins/list");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
            string json = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<ApiModel>>(json);
            if (result != null)
            {
                ApiModel? searchedObject = result.FirstOrDefault(r => r.Name.ToLower() == name.ToLower());
                if (searchedObject != null)
                {
                    return await GetById(searchedObject.Id);
                }
            }

            throw new Exception("There was a problem getting that type of currency");
        }


        private async Task<CoinModel> GetById(String id)
        {
            HttpResponseMessage response = await Client.GetAsync($"coins/{id}");
            if (response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }

            string json = await response.Content.ReadAsStringAsync();
            if (json == null)
            {
                throw new HttpRequestException();
            }
            var result = JsonConvert.DeserializeObject<ApiModel>(json);

            if (result == null)
            {
                throw new JsonSerializationException();
            }

            CoinModel coin = new()
            {
                Name = result.Name,
                CurrentPrice = result.CurrentPrice,
                PriceChangePercentage24H = result.PriceChangePercentage24h,
                Image = result.Image,
            };
            return coin;

        }

        public void PopulateList()
        {
            var tenCoins = context.Coins.OrderBy(CoinModel => CoinModel.CurrentPrice).Take(10);
            foreach (var coin in tenCoins)
            {
                CoinManager.CoinManager.coinList.Add(coin);
            }
        }

        public void AddToCoinList(string coinToAdd)
        {

            CoinModel coin = (CoinModel)context.Coins.Where(c => c.Name.ToLower() == coinToAdd.ToLower());

            if (coin != null)
            {
                CoinManager.CoinManager.coinList.Add(coin);
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
