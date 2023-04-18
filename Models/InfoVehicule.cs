using GestionAuto.AppConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GestionAuto.Models
{
    [Serializable]
    internal class InfoVehicule
    {

        private static XmlSerializer deserializer;
        private static XmlSerializer serializer;
        

        public string name { get; set; }
        public string text { get; set; }

        public InfoVehicule(string name, string text)
        {
            this.name = name;
            this.text = text;
        }

        private static XmlSerializer Deserializer
        {
            get
            {
                if (deserializer == null)
                    deserializer = new XmlSerializer(typeof(InfoVehicule));
                return deserializer;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if (serializer == null)
                {
                    serializer = new XmlSerializer(typeof(InfoVehicule));
                }
                return serializer;
            }
        }
        
    }
}
