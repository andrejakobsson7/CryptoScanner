namespace CryptoScanner.UI.Viewmodels
{
    public class CoinViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int? CurrentPrice { get; set; }
        public double? PriceChangePercentage24H { get; set; }
    }
}
