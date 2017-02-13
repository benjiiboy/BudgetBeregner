using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetBeregner.ViewModel;
using Windows.UI.Popups;

namespace BudgetBeregner.Handler
{
   public class BudgetHandler
    {
        public BudgetViewModel bvm { get; set; }

        public BudgetHandler(BudgetViewModel Bvm)
        {
            this.bvm = Bvm;
        }


        public async void CreateBudget()
        {
            try
            {
            Model.Budget tempbudget = new Model.Budget();

            tempbudget.Name = bvm.Name;
            tempbudget.Price = bvm.Price;
            tempbudget.ComboBoxIndex2 = bvm.ComboBoxIndex;

            Model.BudgetCatalogSingleton.Instancebudget.AddBudget(tempbudget);
            Persistency.PersistencyService.SaveEventAsJsonAsync();
            
            }
            catch (Exception x)
            {

                var dialog = new MessageDialog(x.Message);
                await dialog.ShowAsync();
            }

        }


        public void DeleteBudget()
        {
            Model.BudgetCatalogSingleton.Instancebudget.Remove(bvm.SelectedBudget);
            Persistency.PersistencyService.SaveEventAsJsonAsync();
        }

        public void Rydliste()
        {
            Model.BudgetCatalogSingleton.Instancebudget.BudgetListe.Clear();
            Persistency.PersistencyService.SaveEventAsJsonAsync();
            
        }


    }
}
