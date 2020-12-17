using System;
using System.Collections.Generic;
using System.Text;

namespace Coinage.Core.Interfaces
{
    public interface IDimensionDataService<DimensionType>
    {
        IEnumerable<DimensionType> GetDimensions();
    }
}
