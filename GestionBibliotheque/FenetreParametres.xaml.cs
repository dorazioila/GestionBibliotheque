using System.Runtime.Versioning;
using System.Windows;
namespace GestionBibliothequeLibrary
{
    public partial class FenetreParametres : Window
    {
        [SupportedOSPlatform("windows")]
        MyAppParamManager manager = new MyAppParamManager();

        public FenetreParametres()
        {
            InitializeComponent();
            txtCheminDossier.Text = manager.CheminDossierSauvegarde;
            txtNomBiblio.Text = manager.NomBibliotheque;
        }

        private void btnSauvegarder_Click(object sender, RoutedEventArgs e)
        {
            manager.CheminDossierSauvegarde = txtCheminDossier.Text;
            manager.NomBibliotheque = txtNomBiblio.Text;
            this.Close();
        }
    }
}