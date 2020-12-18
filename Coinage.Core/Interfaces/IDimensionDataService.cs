using System.Collections.Generic;

namespace Coinage.Core.Interfaces
{
    public interface IDimensionDataService<DimensionType>
    {
        IEnumerable<DimensionType> GetDimensions();
    }
}
