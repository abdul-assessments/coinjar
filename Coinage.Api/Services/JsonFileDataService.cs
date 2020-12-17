using Coinage.Api.Data.Models;
using Coinage.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Coinage.Api.Services
{
    public class JsonFileDataService : IVolumeConstantsDataService, IDimensionDataService<ICircularCoinDimension>
    {
        private VolumeConstants _volumeConstants;
        private IEnumerable<ICircularCoinDimension> _dimensions;
        public JsonFileDataService(string rootFolder, string countryCode)
        {
            try
            {
                _volumeConstants = JsonConvert.DeserializeObject<VolumeConstants>(File.ReadAllText(rootFolder + "/VolumeConstants.json"));
                _dimensions = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<ICircularCoinDimension>>>(File.ReadAllText(rootFolder + "/Dimensions.json"))[countryCode];
            }
            catch
            {
                _volumeConstants = new VolumeConstants();
                _dimensions = new List<ICircularCoinDimension>();
            }
        }

        public IEnumerable<ICircularCoinDimension> GetDimensions()
        {
            return _dimensions;
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
