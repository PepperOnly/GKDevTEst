using API.Enums;
using API.Helpers;
using API.Interfaces;
using API.Repository;
using API.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    /// <summary>
    /// CoinJar class, Implimintation of Given ICoinJar Interface
    /// </summary>
    public class CoinJar : ICoinJar
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Dependancy injection for DB part
        /// </summary>
        /// <param name="unitOfWork"> UnitOfWork</param>
        public CoinJar(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Add a new coin, reccieves an ICoin, uses reflection to get Type of coin and creates a new Coin object once done it will save it to the DB
        /// </summary>
        /// <param name="coin"></param>
        public void AddCoin(ICoin coin)
        {
            //Go to DB
            var c = new Coin(coin.GetPropValue<Enums.Type>("Type"));
            var coinEntity = c.ToEntity(coin);

            _unitOfWork.CoinRepository.Add(coinEntity);
            _unitOfWork.SaveChanges();

        }

        /// <summary>
        /// Gets the ammount of money currently stored in the Coin Jar
        /// </summary>
        /// <returns>Total ammount of money in Jar</returns>
        public decimal GetTotalAmount()
        {
            var coins = GetAllCoins().Result;
            var result = 0.0m;

            foreach (var coin in coins)
            {
                result += coin.Ammount;
            }

            return result;
        }

        private async Task<IEnumerable<CoinEntity>> GetAllCoins()
        {
            return await _unitOfWork.CoinRepository.GetAll();
        }

        /// <summary>
        /// Removes all coins from the Jar
        /// </summary>
        public void Reset()
        {
            var numOfRecords = _unitOfWork.CoinRepository.DeletAll().Result;
            _unitOfWork.SaveChanges();
        }
    }
}
