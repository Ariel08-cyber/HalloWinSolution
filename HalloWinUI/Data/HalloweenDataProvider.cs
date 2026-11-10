using HalloWinUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HalloWinUI.Data
{
    public class HalloweenDataProvider : IHalloweenDataProvider
    {
        private static List<Maison>? _maisons;
        private static List<Enfant>? _enfants;
        private static int _prochainIdMaison = 1;
        private static int _prochainIdEnfant = 1;

        private void InitialiserMaisons()
        {
            AjouterMaison(new Maison("123", "Rue des Fantômes", "Gatineau", "J8X 1A1", estSignalee: true));
            AjouterMaison(new Maison("456", "Avenue des Citrouilles", "J8X 2B2", "Gatineau"));
            AjouterMaison(new Maison("789", "Boulevard Hanté", "J8Y 3C3", "Gatineau"));
            AjouterMaison(new Maison("321", "Chemin des Sorcières", "J8Y 4D4", "Gatineau"));
        }

        private void InitialiserEnfants()
        {
            AjouterEnfant(new Enfant("Alice"));
            AjouterEnfant(new Enfant("Hugo"));
            AjouterEnfant(new Enfant("Léa"));
            AjouterEnfant(new Enfant("Noah"));
        }

        public List<Maison> GetMaisons()
        {
            if (_maisons == null)
            {
                _maisons = new List<Maison>();
                InitialiserMaisons();
            }

            return _maisons;
        }

        public List<Enfant> GetEnfants()
        {
            if (_enfants == null)
            {
                _enfants = new List<Enfant>();
                InitialiserEnfants();
            }

            return _enfants;
        }

        public void AjouterMaison(Maison maison)
        {
            ArgumentNullException.ThrowIfNull(maison);

            maison.Id = _prochainIdMaison++;
            _maisons.Add(maison);
        }

        public void AjouterEnfant(Enfant enfant)
        {
            ArgumentNullException.ThrowIfNull(enfant);

            enfant.Id = _prochainIdEnfant++;
            _enfants.Add(enfant);
        }

        public void SupprimerMaison(int maisonId)
        {
            Maison? maison = _maisons.FirstOrDefault(m => m.Id == maisonId);
            if (maison != null)
            {
                _maisons.Remove(maison);
            }
        }

        public void ModifierMaison(Maison maison)
        {
            Maison? existante = _maisons.FirstOrDefault(m => m.Id == maison.Id);
            if (existante != null)
            {
                existante.NumeroCivique = maison.NumeroCivique;
                existante.Rue = maison.Rue;
                existante.Ville = maison.Ville;
                existante.CodePostal = maison.CodePostal;
                existante.EstSignalee = maison.EstSignalee;
            }
        }

        public void SupprimerEnfant(int enfantId)
        {
            Enfant? enfant = _enfants.FirstOrDefault(e => e.Id == enfantId);
            if (enfant != null)
            {
                _enfants.Remove(enfant);
            }
        }

        public void ModifierEnfant(int id, string nom)
        {
            Enfant? existant = _enfants.FirstOrDefault(e => e.Id == id);
            if (existant != null)
            {
                existant.Nom = nom;
            }
        }
    }
}
