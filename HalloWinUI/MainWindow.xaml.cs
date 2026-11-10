using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Linq;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace HalloWinUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NavView_SelectionChanged(
    NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItemContainer != null)
            {
                Type navPageType = Type.GetType(args.SelectedItemContainer.Tag.ToString());
                NavView_Navigate(navPageType, args.RecommendedNavigationTransitionInfo);
            }
        }

        private void NavView_Navigate(
            Type navPageType, NavigationTransitionInfo transitionInfo)
        {
            if (navPageType is not null)
            {
                ContentFrame.Navigate(navPageType, null, transitionInfo);
            }
        }

        private void NavView_BackRequested(NavigationView sender,
            NavigationViewBackRequestedEventArgs args)
        {
            TryGoBack();
        }

        private bool TryGoBack()
        {
            if (!ContentFrame.CanGoBack)
            {
                return false;
            }
            else
            {
                ContentFrame.GoBack();
                return true;
            }
        }

        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            NavView.IsBackEnabled = ContentFrame.CanGoBack;

            if (ContentFrame.SourcePageType != null)
            {
                // Trouver l'élément du menu qui correspond à la page affichée
                NavigationViewItem? item = NavView.MenuItems
                    .OfType<NavigationViewItem>()
                    .FirstOrDefault(i => i.Tag.Equals(ContentFrame.SourcePageType.FullName));

                // Afficher dans l'entête le titre de la page lorsque AlwaysShowHeader="True" dans MainWindow.xaml
                // Pour les sous-pages qui ne sont pas dans le menu, on garde alors la sélection actuelle
                if (item != null)
                {
                    NavView.SelectedItem = item;
                    NavView.Header = item.Content?.ToString();
                }


            }
        }

        private void ContentFrame_NavigationFailed(
                object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Impossible de charger la page " +
                e.SourcePageType.FullName);
        }
    }
}
