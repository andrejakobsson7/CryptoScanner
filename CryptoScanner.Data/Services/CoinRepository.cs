using CryptoScanner.Data.Database;
using CryptoScanner.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoScanner.Data.Services
{
    public class CoinRepository : ICoinRepository
    {
        private readonly AppDbContext _context;

        public CoinRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CoinModel> GetCoins()
        {
            return _context.Coins;
        }

        public CoinModel? GetCoin(string coinName)
        {
            return _context.Coins.FirstOrDefault(c => c.Name == coinName);
        }
    }
}
