using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coinage.Api.Config;
using Coinage.Api.Extensions.MemoryCache;
using Coinage.Api.Models;
using Coinage.Api.Services;
using Coinage.Core.Classes;
using Coinage.Core.Interfaces;
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
        private CoinJar _coinJar;
        private CircularCoinFactory _coinFactory;
        private JsonFileDataService _dataService;
        public CoinJarController(IMemoryCache cache, IOptions<CoinageConfig> coinageConfig)
        {                       
            _dataService = new JsonFileDataService("/Data", coinageConfig.Value.Type);
            _coinJar = new CoinJar(cache.Initialize(_dataService));
            _coinFactory = new CircularCoinFactory(_dataService);
        }

        [Route("addcoin")]
        [HttpPost]
        public IActionResult AddCoinToJar(decimal amount)
        {
            try
            {
                ICoin coin = _coinFactory.GetCoin(amount);
                _coinJar.AddCoin(coin);
                return Ok($"Remaining volume in cointaner - {_coinJar.RemainingVolume}");
            }
            catch
            {
                return BadRequest("Not enough space in jar for coin");
            }
        }

        [Route("getamount")]
        [HttpGet]
        public IActionResult GetAmountInJar()
        {
            try
            {
                return Ok(_coinJar.GetTotalAmount());
            }
            catch
            {
                return BadRequest();
            }
        }

        [Route("reset")]
        [HttpGet]
        public IActionResult ResetCoins()
        {
            try
            {
                _coinJar.Reset();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }            
        }
    }
}