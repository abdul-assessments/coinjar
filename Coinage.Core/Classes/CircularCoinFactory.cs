using Coinage.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coinage.Core.Classes
{    
    public class CircularCoinFactory : ICoinFactory
    {
        private IEnumerable<ICircularCoinDimension> _dimensions;
        public CircularCoinFactory(IEnumerable<ICircularCoinDimension> dimensions)
        {
            _dimensions = dimensions;
        }

        public CircularCoinFactory(IDimensionDataService<ICircularCoinDimension> dataService)
        {
            _dimensions = dataService.GetDimensions();
        }

        public ICoin GetCoin(decimal amount)
        {
            ICircularCoinDimension dimension = _dimensions.FirstOrDefault(x => x.Amount.Equals(amount));
            ICoin newCoin = Activator.CreateInstance<ICoin>();

            if (dimension != default(ICircularCoinDimension)){
                newCoin.Amount = dimension.Amount;
                newCoin.Volume = GetVolume(dimension.Diameter, dimension.Height);
            }

            return newCoin;
        }

        private decimal GetVolume(double diameter, double height)
        {
            return Convert.ToDecimal(Math.PI * Math.Pow(diameter / 2, 2) * height);
        }
    }
}
