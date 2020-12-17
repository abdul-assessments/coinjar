using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coinage.Api.Config;
using Coinage.Api.Extensions.MemoryCache;
using Coinage.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Coinage.Api.Controllers
{
    [Route("api/coinjar")]
    [ApiController]
    public class CoinJarController : ControllerBase
    {
        private IMemoryCache _cache;
        private JsonFileDataService _dataService;
        public CoinJarController(IMemoryCache cache, IOptions<CoinageConfig> coinageConfig)
        {                       
            _dataService = new JsonFileDataService("/Data", coinageConfig.Value.Type);
            cache.Initialize(_dataService);
            _cache = cache;
        }

        [Route("addcoin")]
        [HttpPost]
        public string AddCoinToJar()
        {

        }

        [Route("getamount")]
        [HttpGet]
        public decimal GetAmountInJar()
        {
            return _cache.GetJarTotalAmount();
        }

        [Route("reset")]
        [HttpGet]
        public string ResetCoins()
        {

        }
    }
}