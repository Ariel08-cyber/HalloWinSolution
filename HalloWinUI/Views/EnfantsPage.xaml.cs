using HalloWinUI.Data;
using HalloWinUI.Models;
using HalloWinUI.ViewModels;
using HalloWinUI.ViewModels.Pages;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace HalloWinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EnfantsPage : Page
    {
        public MainEnfantsViewModel ViewModel { get; }

        public EnfantsPage()
        {
            ViewModel = new MainEnfantsViewModel(new HalloweenDataProvider());
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is EnfantViewModel enfant)
            {
                if (enfant.Id == 0) // Nouveau enfant, donc on l'ajoute
                {
                    ViewModel.AjouterEnfant(enfant);
                }
                else // Enfant existant, donc on le modifie
                {
                    ViewModel.ModifierEnfant(enfant);
                }
            }

            ViewModel.ChargerDonnees();
        }

        private void btn_AjouterEnfantClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(FormulaireEnfantPage));
        }

        private void btn_SupprimerEnfantClick(object sender, RoutedEventArgs e)
        {
            if (ViewModel.EnfantSelectionne is null)
            {
                return;
            }

            ViewModel.RetirerEnfant();
        }

        private void btn_ModifierEnfantClick(object sender, RoutedEventArgs e)
        {
            if (ViewModel.EnfantSelectionne is null)
            {
                return;
            }

            Frame.Navigate(typeof(FormulaireEnfantPage), ViewModel.EnfantSelectionne);
        }
    }
}
