using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBeregner.Model
{
    public class Beregninger 
    {
        public double Budgetberegner(int budget)
        {
            double Pris = 0;

            foreach (var i in Model.BudgetCatalogSingleton.Instancebudget.BudgetListe)
            {
                if (i.ComboBoxIndex2 == budget)
                {
                    Pris += i.Price;
                }
            }

            return Pris;
        }

    }
}
