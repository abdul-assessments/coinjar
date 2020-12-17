using System;
using System.Collections.Generic;
using System.Text;

namespace Coinage.Core.Interfaces
{
    public interface ICoinFactory
    {
        ICoin GetCoin(decimal amount);
    }
}
