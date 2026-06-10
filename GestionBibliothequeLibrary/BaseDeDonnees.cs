using System.Collections.ObjectModel;

namespace GestionBibliothequeLibrary
{
    public class BaseDeDonnees
    {
        public ObservableCollection<Livre> Livres { get; set; }
        public ObservableCollection<Membre> Membres { get; set; }
        public ObservableCollection<Emprunt> Emprunts { get; set; }
        public BaseDeDonnees()
        {
            Livres = new ObservableCollection<Livre>();
            Membres = new ObservableCollection<Membre>();
            Emprunts = new ObservableCollection<Emprunt>(); 
        }
    }
}