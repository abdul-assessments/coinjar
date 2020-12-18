using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public CoinJarController(IMemoryCache cache, IVolumeConstantsDataService volumeConstantsDataService, IDimensionDataService<ICircularCoinDimension> dimensionDataService)
        {
            _coinJar = new CoinJar(cache.Initialize(volumeConstantsDataService));
            _coinFactory = new CircularCoinFactory(dimensionDataService);
        }

        [Route("add")]
        [HttpPost]
        public IActionResult AddCoinToJar(PostedCoin postedCoin)
        {
            decimal parsedAmount;
            try
            {
                parsedAmount = Convert.ToDecimal(postedCoin.amount);
            }
            catch (FormatException)
            {
                return Ok("Not a decimal");
            }
            try
            {
                ICoin coin = _coinFactory.GetCoin<Coin>(parsedAmount);
                _coinJar.AddCoin(coin);
                return Ok($"Remaining volume in cointaner : {Math.Round(_coinJar.RemainingVolume, 2)}");
            }
            catch
            {
                return Ok($"Not enough space in jar for coin, remaining volume : {Math.Round(_coinJar.RemainingVolume, 2)}");
            }
        }

        [Route("get")]
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
                return Ok("Jar has been reset.");
            }
            catch
            {
                return BadRequest();
            }            
        }
    }
}