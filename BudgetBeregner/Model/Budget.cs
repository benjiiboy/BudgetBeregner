using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBeregner.Model
{
    public class Budget
    {

        //public string Name { get; set; }
        public double Price { get; set; }
        public int ComboBoxIndex2 { get; set; }

        private string name;

        public string Name  
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Husk Navn");
                name = value;
            }
        }




        public Budget()
        {

        }

        public override string ToString()
        {
            string s;

            s = "Navn på budget post: " + Name + ", ";
            switch (ComboBoxIndex2)
            {
                case 0: s += "Indtægt"; break;
                case 1: s += "Udgift"; break;
            }

            s +=
            ", " + "Price: " + Price;

            return s;
        }

    }
}
