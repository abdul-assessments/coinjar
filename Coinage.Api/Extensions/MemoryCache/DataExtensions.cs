using Coinage.Core.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Coinage.Api.Extensions.MemoryCache
{
    public static class DataExtensions
    {
        public static void Initialize(this IMemoryCache cache, IVolumeConstantsDataService volumeConstants)
        {
            if (!cache.TryGetValue("TotalJarVolume", out decimal val))
            {
                decimal totalJarVolume = volumeConstants.GetTotalJarVolume() * volumeConstants.GetRatioToMm();

                cache.SetJarTotalVolume(totalJarVolume);
                cache.SetJarRemainingVolume(totalJarVolume);
                cache.SetJarTotalAmount(0);
            }
        }        
    }
}
