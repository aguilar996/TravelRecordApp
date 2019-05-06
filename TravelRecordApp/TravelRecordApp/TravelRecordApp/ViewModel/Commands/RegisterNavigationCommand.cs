using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TravelRecordApp.ViewModel.Commands
{
    public class RegisterNavigationCommand : ICommand
        //1. Implementamos el Icomand Interface
    {
        //3.creamos un objeto del tipo del VM que necesitamos
        private MainVM ViewModel;
        public event EventHandler CanExecuteChanged;

        //5. Creamos un Constructor que recibe un VM 
        //y lo asigna al objeto global
        public RegisterNavigationCommand(MainVM viewModel)
        {
            ViewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {//2. Adjuntamos la logica de CanExecute
            return true;
        }

        public void Execute(object parameter)
        {
            //4. llamamos al metodo del ViewModel que se va a ejecutar
            ViewModel.Navigate();
        }
    }
}
