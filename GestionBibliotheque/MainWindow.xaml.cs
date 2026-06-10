using System.Windows;
using System.Windows.Controls;

namespace GestionBibliothequeLibrary
{
    public partial class MainWindow : Window
    {
        BaseDeDonnees maBaseDeDonnees;
        GestionnaireDonnees gestionnaire = new GestionnaireDonnees();

        string cheminSauvegarde = "bibliotheque.json";

        public MainWindow()
        {
            InitializeComponent();
            maBaseDeDonnees = gestionnaire.Charger(cheminSauvegarde);
            if (maBaseDeDonnees.Membres.Count == 0 || maBaseDeDonnees.Membres.Count == 2 )
            {
                maBaseDeDonnees.Membres.Add(new Membre { Nom = "Dupont", Prenom = "Jean" });
                maBaseDeDonnees.Membres.Add(new Membre { Nom = "Durand", Prenom = "Marie" });
                maBaseDeDonnees.Membres.Add(new Membre { Nom = "D'orazio", Prenom = "Louis" });
                maBaseDeDonnees.Membres.Add(new Membre { Nom = "Garant", Prenom = "Leni" });
                gestionnaire.Sauvegarder(maBaseDeDonnees, cheminSauvegarde);
            }
            if (maBaseDeDonnees.Emprunts.Count == 0 && maBaseDeDonnees.Livres.Count > 0)
            {
                maBaseDeDonnees.Emprunts.Add(new Emprunt
                {
                    Emprunteur = maBaseDeDonnees.Membres[0], 
                    LivreEmprunte = maBaseDeDonnees.Livres[0], 
                    DateEmprunt = System.DateTime.Now,
                    DateRetourPrevue = System.DateTime.Now.AddDays(15) 
                });
            }
            this.DataContext = maBaseDeDonnees;
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            maBaseDeDonnees.Livres.Add(new Livre
            {
                Titre = txtTitre.Text,
                Auteur = txtAuteur.Text,
                AnneeParution = 2024,
                CheminImageCouverture = "C:\\Users\\doraz\\Pictures\\couverture.webp",
                DateAjout = dpDateAjout.SelectedDate ?? System.DateTime.Now
            });

            gestionnaire.Sauvegarder(maBaseDeDonnees, cheminSauvegarde);

            txtTitre.Clear();
            txtAuteur.Clear();
        }
        private void dgvLivres_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            Dispatcher.BeginInvoke(new System.Action(() =>
            {
                gestionnaire.Sauvegarder(maBaseDeDonnees, cheminSauvegarde);
            }), System.Windows.Threading.DispatcherPriority.Background);
        }
        private void btnParametres_Click(object sender, RoutedEventArgs e)
        {
            FenetreParametres win = new FenetreParametres();
            win.Owner = this;
            win.ShowDialog();
        }
        private void dgvLivres_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Delete)
            {
                Dispatcher.BeginInvoke(new System.Action(() =>
                {
                    gestionnaire.Sauvegarder(maBaseDeDonnees, cheminSauvegarde);
                    System.Diagnostics.Debug.WriteLine("Livre supprimé et base sauvegardée.");
                }), System.Windows.Threading.DispatcherPriority.Background);
            }
        }

        private void btnAjouterEmprunt_Click(object sender, RoutedEventArgs e)
        {
        
            if (cbMembres.SelectedItem is Membre membreSelectionne &&
                cbLivres.SelectedItem is Livre livreSelectionne)
            {
                Emprunt nouvelEmprunt = new Emprunt
                {
                    Emprunteur = membreSelectionne,
                    LivreEmprunte = livreSelectionne,
                    DateEmprunt = DateTime.Now,
                    DateRetourPrevue = dpRetour.SelectedDate ?? DateTime.Now.AddDays(14),
                    EstRendu = false
                };
                maBaseDeDonnees.Emprunts.Add(nouvelEmprunt);
                gestionnaire.Sauvegarder(maBaseDeDonnees, cheminSauvegarde);
                cbMembres.SelectedIndex = -1;
                cbLivres.SelectedIndex = -1;
                dpRetour.SelectedDate = null;

                MessageBox.Show("Emprunt enregistré avec succès !");
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un membre et un livre.");
            }
        }

    }
}