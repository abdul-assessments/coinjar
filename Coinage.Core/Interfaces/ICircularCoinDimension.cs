﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Coinage.Core.Interfaces
{
    public interface ICircularCoinDimension
    {
        decimal Amount { get; set; }
        double Diameter { get; set; }
        double Height { get; set; }
    }
}
