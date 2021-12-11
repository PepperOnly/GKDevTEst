using API.Helpers;
using API.Interfaces;
using API.Repository.Entities;
using API.Enums;

namespace API
{
    /// <summary>
    /// Coin class, Implimintation of given Interface ICoin
    /// </summary>
    public class Coin : ICoin
    {
        private decimal _amount;
        private decimal _volume;

        private Type _type;

        /// <summary>
        /// Value of the actual coin 0.01/0.1/0.25 in US Dollars
        /// </summary>
        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        /// <summary>
        /// The voloume of the actual Coin in Oz
        /// </summary>
        public decimal Volume
        {
            get { return _volume; }
            set { _volume = value; }
        } 

        /// <summary>
        /// The Type of the Coin        
        /// </summary>
        /// <example>Penny/Nickel/Dime/Quarter</example>
        public Type Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Constructor, creates a new Coin object based on the Type provided
        /// </summary>
        /// <param name="type"></param>
        public Coin(Type type)
        {
            _type = type;

            switch (type)
            {
                case Type.Penny:
                    _amount = 0.01m;
                    _volume = 0.09m;
                    break;
                case Type.Nickel:
                    _amount = 0.05m;
                    _volume = 0.18m;
                    break;
                case Type.Dime:
                    _amount = 0.1m;
                    _volume = 0.08m;
                    break;
                case Type.Quarter:
                    _amount = 0.25m;
                    _volume = 0.2m;
                    break;
                default:
                    _amount = 0.0m;
                    _volume = 0.0m;
                    break; 
            }            
        }
        
        
        /// <summary>
        /// Converts a Coin Interface 'ICoin' to a CoinEntity for DB storage and uses Reflection to get the unknown parameters.
        /// </summary>
        /// <param name="coin"> type ICoin</param>
        /// <returns>CoinEntity</returns>
        public CoinEntity ToEntity(ICoin coin)
        {
            return new CoinEntity
            {                
                Ammount = coin.Amount,
                Volume = coin.Volume,
                Type = coin.GetPropValue<Type>("Type")
            };
        }

        /// <summary>
        /// Converts a Coin Object to a CoinEntity for DB Storage.
        /// </summary>
        /// <param name="coin">type Coin</param>
        /// <returns>CoinEntity</returns>
        public CoinEntity ToEntity(Coin coin)
        {
            return new CoinEntity
            {
                Ammount = coin.Amount,
                Volume = coin.Volume,
                Type = coin.Type
            };
        }
    }
}
