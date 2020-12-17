using Coinage.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coinage.Core.Classes.Base
{
    public abstract class CoinJarBase : ICoinJar
    {
        protected decimal _totalVolume;
        protected decimal _remainingVolume;
        protected decimal _totalAmount;

        public void AddCoin(ICoin coin)
        {
            if (_remainingVolume > coin.Volume)
            {
                _remainingVolume -= coin.Volume;
                _totalAmount += coin.Amount;
                UpdatePersistenceLayer();
            }
            else
            {
                throw new Exception();
            }
        }

        public decimal GetTotalAmount()
        {
            return _totalAmount;
        }

        public void Reset()
        {
            _remainingVolume = _totalVolume;
            _totalAmount = 0;
            UpdatePersistenceLayer();
        }

        protected abstract void UpdatePersistenceLayer();
    }
}
