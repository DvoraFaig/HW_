using System;
using System.Collections.Generic;
using ObserverSystem;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;
using Enums;
using dataExceptions;


namespace ObserverSystem
{
    public sealed class ObservationList : IMeansObservationOperations, ICloneable
    {
        private List<MeansObservation> meansObservations;

        #region singlton
        private static readonly Lazy<ObservationList> lazy =
        new Lazy<ObservationList>(() => new ObservationList());
        public static ObservationList Instance { get { return lazy.Value; } }
        #endregion

        private ObservationList()
        {
            try
            {
                List<ObservationData> data = JsonFileUtils.Read();
                meansObservations = new List<MeansObservation>();
                foreach (var item in data)
                {
                    meansObservations.Add(new MeansObservation((ObservationType)item.Type, item.AerialRange, item.VisionField));
                }
            }
            catch (Exception)
            {

            }
        }

        public void AddObserver(int type, int range, int visionField) 
        {
            try
            {
                MeansObservation newObject = new MeansObservation((ObservationType)type, range, visionField);
                meansObservations.Add(newObject);
                updateData();
            }
            catch (UnableAccessDataException e)
            {
                throw e;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteObservation(int index) 
        {
            try
            {
                MeansObservation deletedObject = meansObservations[index];
                meansObservations.Remove(deletedObject);
                updateData();
            }
            catch (UnableAccessDataException e)
            {
                throw e;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
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
            return objectsToSort.OrderBy(ob => ob.VisionField).ToList();
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

        private void updateData()
        {
            try
            {
                JsonFileUtils.Write(meansObservations);
            }
            catch (UnableAccessDataException e)
            {
                throw e;
            }
        }
    }
}
