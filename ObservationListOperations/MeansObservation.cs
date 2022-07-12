using System;
using Enums;


namespace ObserverSystem

{
    public class MeansObservation:ICloneable, IComparable
    {
        public ObservationType Type { get; set; }
        public int AerialRange { 
            get; 
            set;  
            /*  get { return AerialRange; }
              set  { VisionField = value % 360; }*/
        }
        public int VisionField { get; set; }

        public MeansObservation(ObservationType type, int aerialRange, int visionField)
        {
            Type = type;
            AerialRange = aerialRange;
            VisionField = visionField;
        }

        public override string ToString()
        {
            return $"Type: {Type}. AerialRange {AerialRange} m. VisionField: {VisionField} degree.";
        }

        public object Clone()
        {
            return new MeansObservation(Type, AerialRange, VisionField);
        }

        public int CompareTo(object obj)
        {
            return (int)AerialRange;
        }

    }
}
