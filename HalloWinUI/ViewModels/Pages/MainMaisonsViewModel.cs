using HalloWinUI.Data;
using HalloWinUI.Models;
using System.Collections.ObjectModel;

namespace HalloWinUI.ViewModels.Pages
{
    public class MainMaisonsViewModel : BaseViewModel
    {
        private readonly IHalloweenDataProvider _dataProvider;

        public ObservableCollection<MaisonViewModel> Maisons { get; } = new ObservableCollection<MaisonViewModel>();

        private MaisonViewModel _nouvelleMaison;

        public MaisonViewModel NouvelleMaison
        {
            get { return _nouvelleMaison; }
            set
            {
                if (_nouvelleMaison != value)
                {
                    _nouvelleMaison = value;
                    RaisePropertyChanged();
                }
            }
        }
        private MaisonViewModel? _maisonSelectionnee;

        public MaisonViewModel? MaisonSelectionee
        {
            get { return _maisonSelectionnee; }
            set
            {
                if (_maisonSelectionnee != value)
                {
                    _maisonSelectionnee = value;
                    RaisePropertyChanged();
                }
            }
        }


        public MainMaisonsViewModel(IHalloweenDataProvider halloweenDataProvider)
        {
            _dataProvider = halloweenDataProvider;
            NouvelleMaison = CreerNouvelleMaison();
        }

        private static MaisonViewModel CreerNouvelleMaison()
        {
            return new MaisonViewModel(new Maison());
        }

        public void ChargerDonnees()
        {
            Maisons.Clear();
            foreach (Maison maison in _dataProvider.GetMaisons())
            {
                Maisons.Add(new MaisonViewModel(maison));
            }

        }

        public void AjouterMaison()
        {
            Maison nouvelleMaison = new Maison(
                NouvelleMaison.NumeroCivique,
                NouvelleMaison.Rue,
                NouvelleMaison.Ville,
                NouvelleMaison.CodePostal);
            _dataProvider.AjouterMaison(nouvelleMaison);

            Maisons.Add(NouvelleMaison);
            NouvelleMaison = CreerNouvelleMaison();
        }

        public bool SupprimerMaison()
        {
            if (MaisonSelectionee is null)
                return false;

            Maisons.Remove(MaisonSelectionee);
            return true;
        }

    }
}
