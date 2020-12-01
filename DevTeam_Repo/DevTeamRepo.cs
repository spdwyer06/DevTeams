using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam_Repo
{
    public class DevTeamRepo
    {
        // add devs to a team by dev id
        // remove devs from a team by dev id
        // get list of all devs
        private List<DevTeam> _devTeams = new List<DevTeam>();
        private DeveloperRepo _devRepo = new DeveloperRepo();


        public void CreateDevTeam(DevTeam devTeam)
        {
            _devTeams.Add(devTeam);
        }

        public List<DevTeam> GetAllDevTeams()
        {
            return _devTeams;
        }

        public bool UpdateDevTeamById(int devTeamId, DevTeam updatedTeam)
        {
            var originalDevTeam = GetDevTeamById(devTeamId);

            // Don't want the TeamId to be able to be changed once set
            if (originalDevTeam != null)
            {
                originalDevTeam.TeamName = updatedTeam.TeamName;
                originalDevTeam.Devs = originalDevTeam.Devs;

                return true;
            }
            else
                return false;
        }

        public bool DeleteDevTeamById(int devTeamId)
        {
            var devTeam = GetDevTeamById(devTeamId);
            var previousCount = _devTeams.Count;

            if (devTeam != null)
            {
                _devTeams.Remove(devTeam);

                if (previousCount > _devTeams.Count)
                    return true;
                else
                    return false;
            }

            return false;
        }



        // Helper Method
        public DevTeam GetDevTeamById(int devTeamId)
        {
            foreach (var devTeam in _devTeams)
            {
                if (devTeam.TeamId == devTeamId)
                    return devTeam;
            }

            return null;
        }
    }
}
