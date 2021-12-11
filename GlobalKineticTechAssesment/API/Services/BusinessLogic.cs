using API.Enums;
using API.Interfaces;
using API.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace API.Services
{
    public class BusinessLogic : IBusinessLogic
    {
        private static readonly decimal _MAXVOLUME = 42m;
        private readonly ICoinJar _coinjar;
        private readonly IUnitOfWork _unitOfWork;


        public BusinessLogic(ICoinJar coinJar, IUnitOfWork unitOfWork)
        {
            _coinjar = coinJar;
            _unitOfWork = unitOfWork;   
        }

        public void AddCoin(Enums.Type type)
        {
            //Validate Data
            var coin = new Coin(type);

            try
            {
                if(coin.Amount == 0.0m)
                {
                    throw new Exception("Invalid Coin only US coins allowed Penny/Nickel/Dime/Quarter");
                }

                //Check if coin can fit
                var coins = _unitOfWork.CoinRepository.GetAll().Result.ToList();

                var volume = coins.Sum(x => x.Volume);

                if (volume < _MAXVOLUME && ((coin.Volume + volume) <= _MAXVOLUME))
                {
                    //Add coin
                    _coinjar.AddCoin(coin);
                }
                else
                {
                    throw new Exception("Coin unable to fit in Jar.");
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }       

        public decimal GetTotalAmount()
        {
            return _coinjar.GetTotalAmount();
        }

        public void Reset()
        {
            _coinjar.Reset();
        }
    }
}
