using Coinage.Api.Extensions.MemoryCache;
using Coinage.Core.Classes.Base;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coinage.Api.Models
{
    public class CoinJar : CoinJarBase
    {
        private IMemoryCache _cache;
        public CoinJar(IMemoryCache cache)
        {
            _cache = cache;
            Initialize();
        }
        private void Initialize()
        {
            _totalVolume = _cache.GetJarTotalVolume();
            _totalAmount = _cache.GetJarTotalAmount();
            _remainingVolume = _cache.GetJarRemainingVolume();
        }
        protected override void UpdatePersistenceLayer()
        {
            _cache.SetJarRemainingVolume(_remainingVolume);
            _cache.SetJarTotalAmount(_totalAmount);
        }
    }
}
