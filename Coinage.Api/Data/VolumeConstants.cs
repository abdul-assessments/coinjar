using Coinage.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coinage.Api.Data
{
    public class VolumeConstants : IVolumeConstants
    {
        public decimal MmRatio { get; set; }
        public decimal ContainerVolume { get; set; }
    }
}
