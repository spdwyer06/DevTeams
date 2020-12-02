using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam_Repo
{
    public class DevTeam
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        //public List<Developer> Devs { get; set; }
        public List<Developer> Devs { get; set; } = new List<Developer>();

        public DevTeam() { }

        public DevTeam(int id, string name, List<Developer> devs)
        {
            TeamId = id;
            TeamName = name;
            Devs = devs;
        }
    }
}
