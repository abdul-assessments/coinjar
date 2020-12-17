using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coinage.Api.Extensions.MemoryCache
{
    public static class CoinJarExtensions
    {
        public static decimal GetJarTotalVolume(this IMemoryCache cache)
        {
            return cache.Get<decimal>("TotalJarVolume");
        }

        public static void SetJarTotalVolume(this IMemoryCache cache, decimal volume)
        {
            cache.Set("TotalJarVolume", volume);
        }

        public static decimal GetJarRemainingVolume(this IMemoryCache cache)
        {
            return cache.Get<decimal>("RemainingJarVolume");
        }

        public static void SetJarRemainingVolume(this IMemoryCache cache, decimal volume)
        {
            cache.Set("RemainingJarVolume", volume);
        }

        public static decimal GetJarTotalAmount(this IMemoryCache cache)
        {
            return cache.Get<decimal>("TotalJarAmount");
        }

        public static void SetJarTotalAmount(this IMemoryCache cache, decimal amount)
        {
            cache.Set("TotalJarAmount", amount);
        }
    }
}
