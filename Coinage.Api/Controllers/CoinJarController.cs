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
        private ICoinJar _coinJar;
        private ICoinFactory _coinFactory;
        public CoinJarController(ICoinFactory coinFactory, ICoinJar coinJar)
        {
            _coinJar = coinJar;
            _coinFactory = coinFactory;
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
                return Ok($"Coin added successfully, current amount - {_coinJar.GetTotalAmount()}c");
            }
            catch
            {
                return Ok($"Coin too big, not enough space in jar");
            }
        }

        [Route("get")]
        [HttpGet]
        public IActionResult GetAmountInJar()
        {
            try
            {
                return Ok($"{_coinJar.GetTotalAmount()}c");
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