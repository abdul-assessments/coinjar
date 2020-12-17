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
        public CoinJar(IMemoryCache cache)
        {

        }
        protected override void UpdatePersistenceLayer()
        {
            throw new NotImplementedException();
        }
    }
}
