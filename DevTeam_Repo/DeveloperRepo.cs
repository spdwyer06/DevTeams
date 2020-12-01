using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam_Repo
{
    public class DeveloperRepo
    {
        private List<Developer> _devs = new List<Developer>();


        public void CreateDeveloper(Developer dev)
        {
            _devs.Add(dev);
        }

        public List<Developer> GetAllDevepors()
        {
            return _devs;
        }

        public List<Developer> GetDevelopersNeedingPluralsight()
        {
            var devsWithoutPluralsight = new List<Developer>();

            foreach (var dev in _devs)
            {
                if (!dev.HasPluralsightAccess)
                    devsWithoutPluralsight.Add(dev);
            }

            return devsWithoutPluralsight;
        }

        public bool UpdateDeveloperById(int devId, Developer updatedDev)
        {
            var originalDev = GetDeveloperById(devId);

            if (originalDev != null)
            {
                // Don't want the Id to be able to be changed once set
                originalDev.FirstName = updatedDev.FirstName;
                originalDev.LastName = updatedDev.LastName;
                originalDev.HasPluralsightAccess = updatedDev.HasPluralsightAccess;

                return true;
            }
            else
                return false;

        }

        public bool DeleteDeveloperById(int devId)
        {
            var dev = GetDeveloperById(devId);
            var previousAmtOfDevs = _devs.Count;

            if (dev != null)
            {
                _devs.Remove(dev);

                if (previousAmtOfDevs > _devs.Count)
                    return true;
                else
                    return false;
            }

            return false;
        }



        // Helper Method
        public Developer GetDeveloperById(int devId)
        {
            foreach (var dev in _devs)
            {
                if (dev.Id == devId)
                    return dev;
            }

            return null;
        }
    }
}
