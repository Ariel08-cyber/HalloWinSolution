using HalloWinUI.Data;
using HalloWinUI.ViewModels.Pages;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace HalloWinUI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MaisonsPage : Page
    {
        public MainMaisonsViewModel ViewModel { get; }
        public MaisonsPage()
        {
            ViewModel = new MainMaisonsViewModel(new HalloweenDataProvider());
            InitializeComponent();
            ViewModel.ChargerDonnees();
        }

        private void btn_AjouterMaisonClick(object sender, RoutedEventArgs e)
        {
            if (ViewModel.NouvelleMaison.EstValide)
            {
                ViewModel.AjouterMaison();
            }
        }

        private async void btn_SupprimerMaisonClick(object sender, RoutedEventArgs e)
        {
            ContentDialog dialogueSuppression = new ContentDialog
            {
                Title = "Retirer une maison",
                Content = $"Voulez-vous vraiment supprimer la maison" +
                            $" {ViewModel.MaisonSelectionee.AdresseComplete}" +
                            $" de la liste des maisons ?",
                PrimaryButtonText = "Supprimer",
                CloseButtonText = "Annuler"
            };

            // Permet d'associer la boîte de dialogue à la bonne fenêtre
            dialogueSuppression.XamlRoot = this.XamlRoot;

            ContentDialogResult result = await dialogueSuppression.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                ViewModel.SupprimerMaison();
            }
            
        }
    }
}
