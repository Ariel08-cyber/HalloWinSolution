using HalloWinUI.Data;
using HalloWinUI.Models;
using System.Collections.ObjectModel;

namespace HalloWinUI.ViewModels.Pages
{
    public class MainEnfantsViewModel : BaseViewModel
    {
        private readonly IHalloweenDataProvider _dataProvider;

        public ObservableCollection<EnfantViewModel> Enfants { get; } = new ObservableCollection<EnfantViewModel>();


        private EnfantViewModel? _enfantSelectionne;
        public EnfantViewModel? EnfantSelectionne
        {
            get => _enfantSelectionne;
            set
            {
                if (_enfantSelectionne != value)
                {
                    _enfantSelectionne = value;
                    RaisePropertyChanged();
                }
            }
        }

        public MainEnfantsViewModel(IHalloweenDataProvider halloweenDataProvider)
        {
            _dataProvider = halloweenDataProvider;
        }

        public void ChargerDonnees()
        {
            Enfants.Clear();
            foreach (Enfant enfant in _dataProvider.GetEnfants())
            {
                Enfants.Add(new EnfantViewModel(enfant));
            }
        }

        public void AjouterEnfant(EnfantViewModel enfantVM)
        {
            _dataProvider.AjouterEnfant(new Enfant(enfantVM.Nom));
            // L'enfant sera ajouté à la collection observale au chargement des données,
            // lors de la redirection depuis le formulaire d'ajout.
        }


        public void RetirerEnfant()
        {
            if (EnfantSelectionne == null)
            {
                return;
            }

            _dataProvider.SupprimerEnfant(EnfantSelectionne.Id);
            Enfants.Remove(EnfantSelectionne);
            EnfantSelectionne = null;
        }

        public void ModifierEnfant(EnfantViewModel enfantVM)
        {
            if (enfantVM == null)
            {
                return;
            }
            _dataProvider.ModifierEnfant(enfantVM.Id, enfantVM.Nom);
        }
    }
}
