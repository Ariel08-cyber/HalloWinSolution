using HalloWinUI.Data;
using HalloWinUI.Models;
using System.Collections.ObjectModel;

namespace HalloWinUI.ViewModels.Pages
{
    public class MainMaisonsViewModel
    {

        // commentaire
        private readonly IHalloweenDataProvider _dataProvider;

        public ObservableCollection<Maison> Maisons { get; } = new ObservableCollection<Maison>();

        public MainMaisonsViewModel(IHalloweenDataProvider halloweenDataProvider)
        {
            _dataProvider = halloweenDataProvider;
        }

        public void ChargerDonnees()
        {
            Maisons.Clear();
            foreach (Maison maison in _dataProvider.GetMaisons())
            {
                Maisons.Add(maison);
            }

        }

    }
}
