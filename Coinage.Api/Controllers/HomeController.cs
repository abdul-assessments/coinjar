using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Coinage.Api.Models;
using Coinage.Core.Interfaces;

namespace Coinage.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IDimensionDataService<ICircularCoinDimension> _dimensionDataService;

        public HomeController(ILogger<HomeController> logger, IDimensionDataService<ICircularCoinDimension> dimensionDataService)
        {
            _logger = logger;
            _dimensionDataService = dimensionDataService;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View(_dimensionDataService.GetDimensions());
        }

        [Route("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
