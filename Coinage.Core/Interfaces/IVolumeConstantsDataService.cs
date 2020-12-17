using System;
using System.Collections.Generic;
using System.Text;

namespace Coinage.Core.Interfaces
{
    public interface IVolumeConstantsDataService
    {
        decimal GetRatioToMm();
        decimal GetTotalJarVolume();
    }
}
