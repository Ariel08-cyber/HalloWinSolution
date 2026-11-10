using HalloWinUI.Data;
using HalloWinUI.Models;

namespace HalloWinUI.ViewModels.Pages
{
    public class FormulaireEnfantViewModel : BaseViewModel
    {
        // Cette propriété est utilisée pour déterminer si nous sommes
        // en train d'ajouter un nouvel enfant ou de modifier un enfant existant.
        public string Titre
        {
            get
            {
                if (EnfantEdit.Id == 0)
                {
                    return "Ajouter un enfant";
                } 
                else
                {
                    return "Modifier un enfant";
                }
            }
        }

        private EnfantViewModel _enfantEdit;

        public EnfantViewModel EnfantEdit
        {
            get { return _enfantEdit; }
            set
            {
                if (_enfantEdit != value)
                {
                    _enfantEdit = value;
                    RaisePropertyChanged();
                }
            }
        }

        public FormulaireEnfantViewModel()
        {
            EnfantEdit = new EnfantViewModel(new Enfant());
        }

        public FormulaireEnfantViewModel(EnfantViewModel enfantViewModel)
        {
            EnfantEdit = enfantViewModel;
        }
    }
}
