using Coinage.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coinage.Api.Data
{
    public class CircularDimensions : ICircularCoinDimension
    {
        public decimal Amount { get; set; }
        public double Diameter { get; set; }
        public double Height { get; set; }
    }
}
