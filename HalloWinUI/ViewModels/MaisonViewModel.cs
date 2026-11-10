using HalloWinUI.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace HalloWinUI.ViewModels
{
    public class MaisonViewModel : ValidableViewModel
    {
        private readonly Maison _maison;

        public MaisonViewModel(Maison maison)
        {
            _maison = maison;
            _errors.Add(nameof(NumeroCivique), new ObservableCollection<ValidationResult>());
            _errors.Add(nameof(Rue), new ObservableCollection<ValidationResult>());
            _errors.Add(nameof(Ville), new ObservableCollection<ValidationResult>());
            _errors.Add(nameof(CodePostal), new ObservableCollection<ValidationResult>());
        }

        public int Id => _maison.Id;

        [Required(ErrorMessage = "Obligatoire.")]
        [RegularExpression(@"^\d{1,6}$", ErrorMessage = "1 à 6 chiffres.")]
        public string NumeroCivique
        {
            get { return _maison.NumeroCivique;}
            set
            {
                if (_maison.NumeroCivique != value && Validate(value))
                {
                    _maison.NumeroCivique = value;
                    RaisePropertyChanged();
                }
                else
                {
                    // On valide quand même la valeur même si elle n'a pas changé pour
                    // s'assurer que les erreurs sont mises à jour correctement si on
                    // essaye d'ajouter sans avoir modifié le champs.
                    Validate(value);
                }
            }
        }

        [Required(ErrorMessage = "Obligatoire.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "3 à 100 caractères.")]
        public string Rue
        {
            get { return _maison.Rue; }
            set
            {
                if (_maison.Rue != value && Validate(value))
                {
                    _maison.Rue = value;
                    RaisePropertyChanged();
                }
                else
                {
                    Validate(value);
                }
            }
        }

        [Required(ErrorMessage = "Obligatoire.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "2 à 50 caractères.")]
        [RegularExpression(@"^[\p{L} '’-]+$", ErrorMessage = "Lettres, espaces, - et ' seulement.")]
        public string Ville
        {
            get { return _maison.Ville; }
            set
            {
                if (_maison.Ville != value && Validate(value))
                {
                    _maison.Ville = value;
                    RaisePropertyChanged();
                }
                else
                {
                    Validate(value);
                }
            }
        }

        [Required(ErrorMessage = "Obligatoire.")]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z] ?\d[A-Za-z]\d$", ErrorMessage = "Format A9A 9A9.")]
        public string CodePostal
        {
            get { return _maison.CodePostal; }
            set
            {
                if (_maison.CodePostal != value && Validate(value))
                {
                    _maison.CodePostal = value;
                    RaisePropertyChanged();
                }
                else
                {
                    Validate(value);
                }
            }
        }

        public string AdresseComplete
        {
            get
            {
                return $"{_maison.NumeroCivique} {_maison.Rue}\n{_maison.Ville} {_maison.CodePostal}";
            }
        }

        public bool EstSignalee
        {
            get { return _maison.EstSignalee; }
            set
            {
                if (_maison.EstSignalee != value)
                {
                    _maison.EstSignalee = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
