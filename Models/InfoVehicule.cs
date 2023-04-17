using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAuto.Models
{
    internal class InfoVehicule
    {
        public string name { get; set; }
        public string description { get; set; }

        public InfoVehicule(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
    }
}
