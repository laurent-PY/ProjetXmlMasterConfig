using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GestionAuto.AppConfig.Configurations;

namespace GestionAuto.ViewsModels
{
    internal class ViewsModelsClass
    {
        public static MainWindow main;

        public static void loadType()
        {
            List<string> vehiculeItems = PathConfig.ConfigurationList.FirstOrDefault(x => x.key == "TYPE").ListParam.ConvertAll(p => p.key);
            main.TYPE.ItemsSource = vehiculeItems;
            main.TYPE.SelectedValue = vehiculeItems[0];
        }

        public static void choixVehicule()
        {
            string findVehicule = main.TYPE.SelectedItem.ToString();
            string vehicule = PathConfig.ConfigurationList.FirstOrDefault(x => x.key == "TYPE").ListParam.Find(y => y.key == findVehicule).value.ToString();
            string[] tabSubVehicule = vehicule.Split(';');
            main.VEHICULE.ItemsSource = tabSubVehicule;
            main.VEHICULE.SelectedItem = tabSubVehicule[0];
        }
    }
}
