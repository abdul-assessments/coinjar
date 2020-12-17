using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coinage.Api.Config
{
    public class CoinageConfig
    {
        public static string ConfigSection = "CoinageSystem";
        public string Type { get; set; }
    }
}
