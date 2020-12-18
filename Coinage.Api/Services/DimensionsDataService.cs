using Coinage.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Coinage.Api.Services
{
    public class DimensionsDataService<T> : IDimensionDataService<ICircularCoinDimension> where T : IEnumerable<ICircularCoinDimension>
    {
        private IEnumerable<ICircularCoinDimension> _dimensions;
        public DimensionsDataService(string fileLocation, string countryCode)
        {
            try
            {
                _dimensions = JsonSerializer.Deserialize<Dictionary<string, T>>(File.ReadAllText(fileLocation))[countryCode];
            }
            catch
            {
                _dimensions = new List<ICircularCoinDimension>();
            }
        }

        public IEnumerable<ICircularCoinDimension> GetDimensions()
        {
            return _dimensions;
        }
    }
}
