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
    public sealed partial class FormulaireEnfantPage : Page
    {
        public FormulaireEnfantViewModel ViewModel { get; private set; }

        public FormulaireEnfantPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is EnfantViewModel enfantAModifier)
            {
                EnfantViewModel copie = new EnfantViewModel(new Enfant { Id = enfantAModifier.Id, Nom = enfantAModifier.Nom });

                ViewModel = new FormulaireEnfantViewModel(copie);
            }
            else
            {
                ViewModel = new FormulaireEnfantViewModel();
            }
        }

        private void btn_EnregistrerClick(object sender, RoutedEventArgs e)
        {
            if (ViewModel.EnfantEdit.EstValide)
            {
                Frame.Navigate(typeof(EnfantsPage), ViewModel.EnfantEdit);
            }
        }

        private void btn_AnnulerClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EnfantsPage));
        }

    }
}
