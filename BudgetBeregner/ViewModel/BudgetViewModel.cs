using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using BudgetBeregner.Model;


namespace BudgetBeregner.ViewModel 
{
    public class BudgetViewModel : INotifyPropertyChanged
    {
        private BudgetBeregner.Handler.BudgetHandler budgethandler { get; set; }
        private Model.Beregninger beregninghandler { get; set; }

        public Common.RelayCommand OpdaterPris { get; set; }

        public Common.RelayCommand GemDataPåDiskCommand { get; set; }
        public Common.RelayCommand HentDataPåDiskCommand { get; set; }
        public ICommand CreateBudgetCommand { get; set; }
        public ICommand DeleteBudgetCommand { get; set; }
        public Common.RelayCommand RydListeCommand { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int ComboBoxIndex { get; set; }



        public BudgetViewModel()
        {
            budgethandler = new BudgetBeregner.Handler.BudgetHandler(this);
            myBudgetCatalogSingleton = Model.BudgetCatalogSingleton.Instancebudget;

            Model.BudgetCatalogSingleton.Instancebudget.AddCombobox();
            Opdaterpris();

            OpdaterPris = new Common.RelayCommand(Opdaterpris);
            GemDataPåDiskCommand = new Common.RelayCommand(Persistency.PersistencyService.SaveEventAsJsonAsync);
            HentDataPåDiskCommand = new Common.RelayCommand(Model.BudgetCatalogSingleton.Instancebudget.HentJson);
            CreateBudgetCommand = new Common.RelayCommand(budgethandler.CreateBudget);
            DeleteBudgetCommand = new Common.RelayCommand(budgethandler.DeleteBudget, TomListeCheck);
            RydListeCommand = new Common.RelayCommand(budgethandler.Rydliste, TomListeCheck);

        }


        private Model.Budget selectedBudget;

        public Model.Budget SelectedBudget
        {
            get { return selectedBudget; }
            set
            {
                selectedBudget = value;
                OnPropertyChanged(nameof(SelectedBudget));
            }
        }

        private Model.BudgetCatalogSingleton myBudgetCatalogSingleton;

        public Model.BudgetCatalogSingleton MyBudgetCatalogSingleton { get { return myBudgetCatalogSingleton; } }


        #region OnPropertyChanged
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        public bool TomListeCheck()
        {
            return Model.BudgetCatalogSingleton.Instancebudget.BudgetListe.Count() > 0; 
        }

        public double Pris()
        {
            return beregninghandler.Budgetberegner(0) - beregninghandler.Budgetberegner(1);
        }

        public void Opdaterpris()
        {
            Pris();
        }
    }
}
