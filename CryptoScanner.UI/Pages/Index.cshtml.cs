using CryptoScanner.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CryptoScanner.UI.Pages
{
    public class IndexModel : PageModel
    {
        public List<CoinModel> Coins { get; set; } = new();
        public CoinModel Coin { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Decimal CurrentPrice { get; set; }
        public double PriceChangePercentage24H { get; set; }

        [BindProperty]
        public string CoinName { get; set; }
        public void OnGet()
        {
            CoinModel newCoin = new()
            {
                Name = "Bitcoin",
                Image = "https://assets.coingecko.com/coins/images/1/large/bitcoin.png?1696501400",
                CurrentPrice = 49944,
                PriceChangePercentage24H = 3.70286,
            };
            Coins.Add(newCoin);
            CoinModel newCoin2 = new()
            {
                Name = "Tether",
                Image = "https://assets.coingecko.com/coins/images/325/large/Tether.png?1696501661",
                CurrentPrice = new decimal(1.001),
                PriceChangePercentage24H = -0.04934,
            };
            Coins.Add(newCoin2);
            CoinModel newCoin3 = new()
            {
                Name = "Bitcoin",
                Image = "https://assets.coingecko.com/coins/images/1/large/bitcoin.png?1696501400",
                CurrentPrice = 49944,
                PriceChangePercentage24H = 3.70286,
            };
            Coins.Add(newCoin3);
            CoinModel newCoin4 = new()
            {
                Name = "Tether",
                Image = "https://assets.coingecko.com/coins/images/325/large/Tether.png?1696501661",
                CurrentPrice = new decimal(1.001),
                PriceChangePercentage24H = -0.04934,
            };
            Coins.Add(newCoin4);
            CoinModel newCoin5 = new()
            {
                Name = "Bitcoin",
                Image = "https://assets.coingecko.com/coins/images/1/large/bitcoin.png?1696501400",
                CurrentPrice = 49944,
                PriceChangePercentage24H = 3.70286,
            };
            Coins.Add(newCoin5);
            CoinModel newCoin6 = new()
            {
                Name = "Tether",
                Image = "https://assets.coingecko.com/coins/images/325/large/Tether.png?1696501661",
                CurrentPrice = new decimal(1.001),
                PriceChangePercentage24H = -0.04934,
            };
            Coins.Add(newCoin6);
            //Kör call till mellanlagret som kallar på API. Mellanlagret behöver omvandla till coinmodel och returnera en lista av coin models.
            //Ska klienten eller mellanlagret filtrera ut de 10 som ska visas?
        }
    }
}
