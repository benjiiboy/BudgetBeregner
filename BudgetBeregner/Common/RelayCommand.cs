using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace BudgetBeregner.Common
{
    public class RelayCommand : ICommand
    {

        private DispatcherTimer CanExecutetimer;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute) : this(execute, null)
        {
        }

        private void CanExecutetimer_Tick(object sender, object e)
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        private Action methodToExecute = null;
        private Func<bool> methodToDecectCanExecute = null;

        public RelayCommand(Action methodToExecute, Func<bool> methodToDetectCanExecute)
        {
            this.methodToExecute = methodToExecute;
            this.methodToDecectCanExecute = methodToDetectCanExecute;

            this.CanExecutetimer = new DispatcherTimer();
            this.CanExecutetimer.Tick += CanExecutetimer_Tick;
            this.CanExecutetimer.Interval = new TimeSpan(0, 0, 1);
            this.CanExecutetimer.Start();
        }
        public void Execute(object parameter)
        {
            this.methodToExecute();
        }
        public bool CanExecute(object parameter)
        {
            if (this.methodToDecectCanExecute == null)
            {
                return true;
            }
            else
            {
                return this.methodToDecectCanExecute();
            }
        }
    }
}
