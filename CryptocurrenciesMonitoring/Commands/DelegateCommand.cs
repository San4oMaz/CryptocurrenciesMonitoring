using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptocurrenciesMonitoring.Commands
{
    /// <summary>
    /// Для задавання команд замість стандартних привязок до MainWindow.xaml
    /// </summary>
    class DelegateCommand : ICommand
    {
        protected readonly Action<object> execute;
        protected readonly Func<object, bool> canExecute;

        /// <summary>
        /// Для обновлення всіх команд властивості CanExecute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute != null)
                return canExecute(parameter);
            return true;
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        

        /// <summary>
        /// Конструктори в яких ініціалізовуємо поля-делегати для команд.
        /// </summary>
        /// <param name="executeAction"></param>
        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteFunc = null)
        {
            execute = executeAction ?? throw new ArgumentNullException(nameof(executeAction));
            canExecute = canExecuteFunc;
        }

    }
} 
