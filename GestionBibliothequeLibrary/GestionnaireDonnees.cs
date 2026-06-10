using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GestionBibliothequeLibrary
{
    public class GestionnaireDonnees
    {
        private JsonSerializerOptions _options;

        public GestionnaireDonnees()
        {
            _options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };
        }
        public void Sauvegarder(BaseDeDonnees bdd, string cheminFichier)
        {
            string jsonString = JsonSerializer.Serialize(bdd, _options);
            File.WriteAllText(cheminFichier, jsonString);
        }
        public BaseDeDonnees Charger(string cheminFichier)
        {
            if (!File.Exists(cheminFichier)) return new BaseDeDonnees();
            try
            {
                string jsonString = File.ReadAllText(cheminFichier);
                return JsonSerializer.Deserialize<BaseDeDonnees>(jsonString, _options) ?? new BaseDeDonnees();
            }
            catch
            {
                return new BaseDeDonnees();
            }
        }
    }
}