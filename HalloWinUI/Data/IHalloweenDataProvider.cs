using HalloWinUI.Models;
using System.Collections.Generic;

namespace HalloWinUI.Data
{
    public interface IHalloweenDataProvider
    {
        // Méthodes de gestion des maisons
        List<Maison> GetMaisons();
        void AjouterMaison(Maison maison);
        void SupprimerMaison(int maisonId);
        void ModifierMaison(Maison maison);

        // Méthodes de gestion des enfants
        List<Enfant> GetEnfants();
        void AjouterEnfant(Enfant enfant);
        void SupprimerEnfant(int enfantId);
        void ModifierEnfant(int id, string nom);
    }
}
