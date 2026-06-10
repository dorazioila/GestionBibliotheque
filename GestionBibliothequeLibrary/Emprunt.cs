using System;

namespace GestionBibliothequeLibrary
{
    public class Emprunt
    {
        public required Livre LivreEmprunte { get; set; }
        public required Membre Emprunteur { get; set; }
        public DateTime DateEmprunt { get; set; } = DateTime.Now; 
        public DateTime DateRetourPrevue { get; set; }

        public bool EstRendu { get; set; }
    }
}