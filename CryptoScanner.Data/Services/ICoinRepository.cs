using CryptoScanner.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoScanner.Data.Services
{
    public interface ICoinRepository
    {
        public IEnumerable<CoinModel> GetCoins();

        public CoinModel GetCoin(string coinName);
    }
}
