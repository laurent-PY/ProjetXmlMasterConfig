using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace GestionAuto.AppConfig
{
    public class Configurations
    {
        private static XmlSerializer deserializer;
        private static XmlSerializer serializer;

        [XmlElement(ElementName = "Configuration")]
        public List<Configuration> ListConfiguration;

        private static XmlSerializer Deserializer
        {
            get
            {
                if (deserializer == null)
                    deserializer = new XmlSerializer(typeof(Configurations));
                return deserializer;
            }
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if(serializer == null)
                {
                    serializer = new XmlSerializer(typeof(Configurations));
                }
                return serializer;
            }
        }

        internal static Configurations LoadFromFile(string _filename)
        {
            Configurations confs = null;

            using (FileStream fs = new FileStream(_filename, FileMode.Open, FileAccess.Read))
            {
                confs = Deserializer.Deserialize(fs) as Configurations;
            }

            return confs;
        }

        public class Configuration
        {
            [XmlAttribute(AttributeName = "key")]
            public string key { get; set; }

            [XmlElement(ElementName = "param")]
            public List<Parameter> ListParam;

        }

        [XmlRoot(ElementName = "param")]
        public class Parameter
        {
            [XmlAttribute(AttributeName = "key")]
            public string key { get; set; }
            [XmlAttribute(AttributeName = "value")]
            public string value { get; set; }
        }

        public static class PathConfig
        {
            public static List<Configuration> ConfigurationList = new List<Configuration>();

            public static void LoadFile(string _configfilename)
            {
                Configurations confs = LoadFromFile(_configfilename);

                foreach (Configuration conf in confs.ListConfiguration)
                {
                    if (ConfigurationList.Exists(x => x.key.ToUpper() == conf.key.ToUpper()))
                    {
                        foreach (Parameter p in conf.ListParam)
                        {
                            if (ConfigurationList.Find(x => x.key == conf.key).ListParam.Exists(x => x.key.ToUpper() == p.key.ToUpper()))
                            {
                                if (!string.IsNullOrWhiteSpace(p.value))
                                {
                                    //On écrase la paramètre existant du fichier maître si la valeur indiquée est différente et non nulle
                                    ConfigurationList.Find(x => x.key.ToUpper() == conf.key.ToUpper()).ListParam.Find(y => y.key.ToUpper() == p.key.ToUpper()).value = p.value;
                                }
                                else
                                {
                                    //Ajout d'un nouveau paramètre
                                    ConfigurationList.Find(x => x.key.ToUpper() == conf.key.ToUpper()).ListParam.Add(p);
                                }
                            }
                        }
                    }
                    else
                    {
                        ConfigurationList.Add(conf);
                    }
                }
            }
        }
    }
}
