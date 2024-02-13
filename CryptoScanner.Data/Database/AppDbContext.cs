using CryptoScanner.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoScanner.Data.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<CoinModel> Coins { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CoinModel>().HasData(
                new CoinModel()
                {
                    Id = 1,
                    Name = "bitcoin",
                    Image = "https://assets.coingecko.com/coins/images/1/large/bitcoin.png?1696501400",
                    CurrentPrice = (decimal?)519641,
                    PriceChangePercentage24H = 0.46958
                },
                new CoinModel()
                {
                    Id = 2,
                    Name = "ethereum",
                    Image = "https://assets.coingecko.com/coins/images/279/large/ethereum.png?1696501628",
                    CurrentPrice = (decimal?)27718,
                    PriceChangePercentage24H = 1.74117
                },
                new CoinModel()
                {
                    Id = 3,
                    Name = "tether",
                    Image = "https://assets.coingecko.com/coins/images/325/large/Tether.png?1696501661",
                    CurrentPrice = (decimal?)10.6,
                    PriceChangePercentage24H = 1.94537
                },
                new CoinModel()
                {
                    Id = 4,
                    Name = "bnb",
                    Image = "https://assets.coingecko.com/coins/images/825/large/bnb-icon2_2x.png?1696501970",
                    CurrentPrice = (decimal?)3415.12,
                    PriceChangePercentage24H = 0.86815
                },
                new CoinModel()
                {
                    Id = 5,
                    Name = "solana",
                    Image = "https://assets.coingecko.com/coins/images/4128/large/solana.png?1696504756",
                    CurrentPrice = (decimal?)1184.13,
                    PriceChangePercentage24H = 3.30797
                });



        }
    }
}
