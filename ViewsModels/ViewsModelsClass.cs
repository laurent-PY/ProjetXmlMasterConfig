using GestionAuto.AppConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
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

        public static void choixType()
        {
            string findVehicule = main.TYPE.SelectedItem.ToString();
            string vehicule = PathConfig.ConfigurationList.FirstOrDefault(x => x.key == "TYPE").ListParam.Find(y => y.key == findVehicule).value.ToString();
            string[] tabSubVehicule = vehicule.Split(';');
            main.MARQUE.ItemsSource = tabSubVehicule;
            main.MARQUE.SelectedItem = tabSubVehicule[0];
        }
       
        public static void choixMarque()
        {

            if (main.MARQUE.SelectedItem == null)
            {
                main.MARQUE.SelectedItem = main.MARQUE.Items[0];
            }

            string type = main.TYPE.SelectedItem.ToString();

            string marque = main.MARQUE.SelectedItem.ToString();


            if (type == "Voiture" && marque == "Audi")
            {
                displayModeleVoiture(marque);
            }
            if (type == "Voiture" && marque == "Renault")
            {
                displayModeleVoiture(marque);
            }
            if (type == "Moto" && marque == "Kawasaki")
            {
                displayModeleVoiture(marque);
            }
        }

        public static void displayModeleVoiture(string marque)
        {
            string Marque = marque;
            string modeleItem = PathConfig.ConfigurationList.FirstOrDefault(x => x.key == "MODELE").ListParam.Find(y => y.key == Marque).value.ToString();
            string[] tabListModel = modeleItem.Split(';');
            main.MODELE.ItemsSource = tabListModel;
            main.MODELE.SelectedValue = tabListModel[0];
        }

        public static void MODELE_SelectionChanged()
        {
            if (main.MODELE.SelectedItem == null)
            {
                main.MODELE.SelectedItem = main.MODELE.Items[0];
            }

            if (main.TYPE.SelectedItem == null)
            {
                main.TYPE.SelectedItem = main.TYPE.Items[0];
            }

            
            string modele = main.MODELE.SelectedItem.ToString();
            string comment = PathConfig.ConfigurationList.FirstOrDefault(x => x.key == "COMMENT").ListParam.FirstOrDefault(y => y.key == modele).value.ToString();
            Console.WriteLine(comment);
            main.INFOS.Text = comment;
        }
    }
}
