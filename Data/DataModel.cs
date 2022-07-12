using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;

namespace Data
{
    public class ObservationData
    {
        public ObservationType Type { get; set; }
        public int AerialRange { get; set; }
        public int VisionField { get; set; }
    }
}
