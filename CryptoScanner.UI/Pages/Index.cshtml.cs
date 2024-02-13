using CryptoScanner.Data.Database;
using CryptoScanner.UI.Viewmodels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CryptoScanner.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public IndexModel(AppDbContext context)
        {
            _context = context;
            OrderOptions = GenerateSortingOptions();
        }
        public List<CoinViewModel> Coins { get; set; } = new();
        //public CoinModel Coin { get; set; }
        //public string Name { get; set; }
        //public string Image { get; set; }
        //public Decimal CurrentPrice { get; set; }
        //public double PriceChangePercentage24H { get; set; }
        [BindProperty]
        public string CoinName { get; set; }
        [BindProperty]
        public int OrderType { get; set; }
        public List<SelectListItem> OrderOptions { get; set; } = new();
        public async void OnGet()
        {
            //CoinApiCaller cac = new(_context);
            //await cac.GetAll();

            //cac.PopulateList();

            //Coins = CoinManager.coinList.Select(c => new CoinViewModel()
            //{
            //    Id = c.Id,
            //    Name = c.Name,
            //    CurrentPrice = c.CurrentPrice,
            //    Image = c.Image,
            //    PriceChangePercentage24H = c.PriceChangePercentage24H
            //}).ToList();
            //foreach (var coin in CoinManager.coinList)
            //{
            //    CoinViewModel cvm = new()
            //    {
            //        Name = coin.Name,
            //        Image = coin.Image,
            //        CurrentPrice = coin.CurrentPrice,
            //        PriceChangePercentage24H = coin.PriceChangePercentage24H
            //    };
            //    Coins.Add(cvm);
            //}

            //CoinModel newCoin = new()
            //{
            //    Name = "Bitcoin",
            //    Image = "https://assets.coingecko.com/coins/images/1/large/bitcoin.png?1696501400",
            //    CurrentPrice = 49944,
            //    PriceChangePercentage24H = 3.70286,
            //};
            //Coins.Add(newCoin);
            //CoinModel newCoin2 = new()
            //{
            //    Name = "Tether",
            //    Image = "https://assets.coingecko.com/coins/images/325/large/Tether.png?1696501661",
            //    CurrentPrice = 1,
            //    PriceChangePercentage24H = -0.04934,
            //};
            //Coins.Add(newCoin2);
            //CoinModel newCoin3 = new()
            //{
            //    Name = "Bitcoin",
            //    Image = "https://assets.coingecko.com/coins/images/1/large/bitcoin.png?1696501400",
            //    CurrentPrice = 49944,
            //    PriceChangePercentage24H = 3.70286,
            //};
            //Coins.Add(newCoin3);
            //CoinModel newCoin4 = new()
            //{
            //    Name = "Tether",
            //    Image = "https://assets.coingecko.com/coins/images/325/large/Tether.png?1696501661",
            //    CurrentPrice = 1,
            //    PriceChangePercentage24H = -0.04934,
            //};
            //Coins.Add(newCoin4);
            //CoinModel newCoin5 = new()
            //{
            //    Name = "Bitcoin",
            //    Image = "https://assets.coingecko.com/coins/images/1/large/bitcoin.png?1696501400",
            //    CurrentPrice = 49944,
            //    PriceChangePercentage24H = 3.70286,
            //};
            //Coins.Add(newCoin5);
            //CoinModel newCoin6 = new()
            //{
            //    Name = "Tether",
            //    Image = "https://assets.coingecko.com/coins/images/325/large/Tether.png?1696501661",
            //    CurrentPrice = 1,
            //    PriceChangePercentage24H = -0.04934,
            //};
            //Coins.Add(newCoin6);
            ////Kör call till mellanlagret som kallar på API. Mellanlagret behöver omvandla till coinmodel och returnera en lista av coin models.
            ////Ska klienten eller mellanlagret filtrera ut de 10 som ska visas?
        }

        public async void OnPost()
        {


        }

        private List<SelectListItem> GenerateSortingOptions()
        {
            SelectListItem orderByIdDefault = new()
            {
                Selected = true,
                Value = "0",
                Text = "Id (default)"
            };
            OrderOptions.Add(orderByIdDefault);
            SelectListItem orderByNameAscending = new()
            {
                Value = "1",
                Text = "Name (A-Z)"
            };
            OrderOptions.Add(orderByNameAscending);

            SelectListItem orderByNameDescending = new()
            {
                Value = "2",
                Text = "Name (Z-A)"
            };
            OrderOptions.Add(orderByNameDescending);

            SelectListItem orderByValueAscending = new()
            {
                Value = "3",
                Text = "Value (0-9)"
            };
            OrderOptions.Add(orderByValueAscending);

            SelectListItem orderByValueDescending = new()
            {
                Value = "4",
                Text = "Value (9-0)"
            };
            OrderOptions.Add(orderByValueDescending);
            return OrderOptions;
        }
    }
}
