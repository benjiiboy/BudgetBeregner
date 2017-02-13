using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace BudgetBeregner.Model
{
    public class BudgetCatalogSingleton
    {
        public List<string> ComboBox { get; set; }
  


        private static BudgetCatalogSingleton instanceBudget = new BudgetCatalogSingleton();

        public static BudgetCatalogSingleton Instancebudget
        {
            get { return instanceBudget; }
        }

        public ObservableCollection<Budget> BudgetListe { get; set; }

        public BudgetCatalogSingleton()
        {
            BudgetListe = new ObservableCollection<Budget>();

            BudgetListe.Add(new Budget() { Name = "SU",Price = 1231, ComboBoxIndex2=0});
            HentJson();

        }

        public void AddBudget(Budget newBudget)
        {
            BudgetListe.Add(newBudget);
        }



        public void AddCombobox()
        {
            ComboBox = new List<string>() { "Indtægter", "Udgifter" };
        }

        public void Remove(Budget choseBudget)
        {
            BudgetListe.Remove(choseBudget);
        }

        public async void HentJson()
        {
            BudgetListe = await Persistency.PersistencyService.LoadEventsFromJsonAsync();
        }


        
    }
}
