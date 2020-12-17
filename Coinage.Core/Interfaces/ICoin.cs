using System;
using System.Collections.Generic;
using System.Text;

namespace Coinage.Core.Interfaces
{
    public interface ICoin
    {
        decimal Amount { get; set; }
        decimal Volume { get; set; }
    }
}
