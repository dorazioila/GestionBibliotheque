using System;
using System.Collections.ObjectModel;
namespace GestionBibliothequeLibrary
{
    public class Membre
    {
        public int Id { get; set; }
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public DateTime DateInscription { get; set; } = DateTime.Now;
        public ObservableCollection<Emprunt> HistoriqueEmprunts { get; set; } = new();
        public Membre()
        {
            HistoriqueEmprunts = new ObservableCollection<Emprunt>();
        }
    }
}