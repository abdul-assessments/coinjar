using System;
using System.Collections.Generic;
using System.Text;

namespace Coinage.Core.Interfaces
{
    public interface ICoinJar
    {
        void AddCoin(ICoin coin);
        decimal GetTotalAmount();
        void Reset();
    }
}
