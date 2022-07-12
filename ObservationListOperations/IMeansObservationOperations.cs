using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverSystem;

namespace ObserverSystem
{
    public interface IMeansObservationOperations
    {
        void AddObserver(int type, int range, int visionField);
        void DeleteObservation(int index);
        List<MeansObservation> GetAll();
        List<MeansObservation> GetSpecificType(ObservationType type);
        List<MeansObservation> GetSortedByRange();
        MeansObservation GetMaxObservationWithMinVisionField(int minVisionField);
    }
}
