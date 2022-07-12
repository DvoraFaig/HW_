using System;
using System.Collections.Generic;
using ObserverSystem;

using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ObserverSystem
{
    public sealed class ObservationList : IMeansObservationOperations, ICloneable
    {
        private List<MeansObservation> meansObservations;

        private static readonly Lazy<ObservationList> lazy =
        new Lazy<ObservationList>(() => new ObservationList());
        public static ObservationList Instance { get { return lazy.Value; } }

        private ObservationList()
        {
            meansObservations = new List<MeansObservation>();
        }

        public void AddObserver(int type, int range, int visionField) 
        {
            MeansObservation newObject = new MeansObservation((ObservationType)type, range, visionField);
            meansObservations.Add(newObject);
        }

        public void DeleteObservation(int index) 
        {
            MeansObservation deletedObject = meansObservations[index];
            meansObservations.Remove(deletedObject);
        }
        public List<MeansObservation> GetAll()
        {
            return (List<MeansObservation>)this.Clone();
        }
        public List<MeansObservation> GetSpecificType(ObservationType type)
        {
            List<MeansObservation> allObjects = GetAll();
            List<MeansObservation> filteredObjects = allObjects.FindAll(obj => obj.Type == type);
            return filteredObjects;
        }
        public List<MeansObservation> GetSortedByRange()
        {
            List<MeansObservation> objectsToSort = GetAll();
            objectsToSort.Sort();
            return objectsToSort;
        }
        public MeansObservation GetMaxObservationWithMinVisionField(int minVisionField)
        {
            List<MeansObservation> allObjects = GetAll();
            double maxAerialRange = allObjects.Max(obj => obj.AerialRange);
            return allObjects.Select(obj => obj)
                               .Where(obj => obj.VisionField >= minVisionField && obj.AerialRange == maxAerialRange)
                               .First();
        }

        public object Clone()
        {
            List<MeansObservation> clonedList = new List<MeansObservation>();
            foreach (MeansObservation item in meansObservations)
            {
                clonedList.Add((MeansObservation)item.Clone());
            }
            return clonedList;
        }
    }
}
