using System;

namespace GestionBibliothequeLibrary
{
    public class Livre
    {
        public int Id { get; set; }
        public required string Titre { get; set; }
        public required string Auteur { get; set; }
        public string CheminImageCouverture { get; set; } = "";
        public int AnneeParution { get; set; }
        public DateTime DateAjout { get; set; } = DateTime.Now;
        public string? NomEmprunteur { get; set; }
    }
}