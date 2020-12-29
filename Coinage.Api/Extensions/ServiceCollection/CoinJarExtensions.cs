using Coinage.Api.Models;
using Coinage.Api.Services;
using Coinage.Core.Classes;
using Coinage.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coinage.Api.Extensions.ServiceCollection
{
    public static class CoinJarExtensions
    {
        public static IServiceCollection AddCoinJarWithJsonDependencies(this IServiceCollection services, string volumeConstantsLocation, string dimensionsLocation, string coinageSystem)
        {
            //dataservice dependency registration
            services.AddSingleton<IVolumeConstantsDataService>(new VolumeConstantsDataService<VolumeConstants>(volumeConstantsLocation));
            services.AddSingleton<IDimensionDataService<ICircularCoinDimension>>(new DimensionsDataService<IEnumerable<CircularDimensions>>(dimensionsLocation, coinageSystem));

            //Coin jar and coin factory dependency registration
            services.AddSingleton<ICoinFactory, CircularCoinFactory>();
            services.AddSingleton<ICoinJar, CoinJar>();
            return services;
        }
    }
}
