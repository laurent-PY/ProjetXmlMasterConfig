using GestionAuto.ViewsModels;
using System.Windows;
using static GestionAuto.AppConfig.Configurations;

namespace GestionAuto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PathConfig.LoadFile("MasterConfig.xml");
            ViewsModelsClass.main = this;
        }

        

        private void TYPE_Loaded(object sender, RoutedEventArgs e)
        {
            ViewsModelsClass.loadType();
        }

        private void TYPE_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ViewsModelsClass.choixType();
        }

        private void VEHICULE_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ViewsModelsClass.choixMarque();
        }

        private void MODELE_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ViewsModelsClass.MODELE_SelectionChanged();
        }
    }
}
