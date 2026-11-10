using HalloWinUI.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace HalloWinUI.ViewModels
{
    public class EnfantViewModel : ValidableViewModel
    {
        private readonly Enfant _enfant;

        public EnfantViewModel(Enfant enfant)
        {
            _enfant = enfant;
            _errors.Add(nameof(Nom), new ObservableCollection<ValidationResult>());
            Validate(Nom, nameof(Nom));
        }

        public int Id => _enfant.Id;

        [Required(ErrorMessage = "Le nom est obligatoire.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le nom doit contenir entre 2 et 50 caractères.")]
        [RegularExpression(@"^[\p{L} '’-]+$", ErrorMessage = "Le nom ne peut contenir que des lettres, des espaces, des traits d'union et des apostrophes.")]
        public string Nom
        {
            get { return _enfant.Nom; }
            set
            {
                if (_enfant.Nom != value && Validate(value))
                {
                    _enfant.Nom = value;
                    RaisePropertyChanged();
                }
            }
        }

    }
}
