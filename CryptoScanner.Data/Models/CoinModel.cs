using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoScanner.Data.Models
{
    public class CoinModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public decimal? CurrentPrice { get; set; }
        public double? PriceChangePercentage24H { get; set; }
    }
}
