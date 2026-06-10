using Microsoft.Win32;

namespace GestionBibliothequeLibrary
{
    public class MyAppParamManager
    {
        private const string RegPath = @"Software\GestionBibliotheque";

        public string CheminDossierSauvegarde
        {
            get => (string)Registry.CurrentUser.OpenSubKey(RegPath)?.GetValue("Chemin") ?? @"C:\Temp";
            set => Registry.CurrentUser.CreateSubKey(RegPath).SetValue("Chemin", value);
        }

        public string NomBibliotheque
        {
            get => (string)Registry.CurrentUser.OpenSubKey(RegPath)?.GetValue("Nom") ?? "Ma Bibliothèque";
            set => Registry.CurrentUser.CreateSubKey(RegPath).SetValue("Nom", value);
        }
    }
}