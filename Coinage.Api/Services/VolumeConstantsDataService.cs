using Coinage.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Coinage.Api.Services
{
    public class VolumeConstantsDataService<T> : IVolumeConstantsDataService where T : IVolumeConstants
    {
        private IVolumeConstants _volumeConstants;
        public VolumeConstantsDataService(string fileLocation)
        {
            try
            {
                _volumeConstants = JsonSerializer.Deserialize<T>(File.ReadAllText(fileLocation));
            }
            catch
            {
                _volumeConstants = null;
            }
        }

        public decimal GetRatioToMm()
        {
            return _volumeConstants.MmRatio;
        }

        public decimal GetTotalJarVolume()
        {
            return _volumeConstants.ContainerVolume;
        }        
    }
}
