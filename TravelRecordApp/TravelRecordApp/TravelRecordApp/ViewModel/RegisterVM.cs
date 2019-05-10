using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel.Commands;

namespace TravelRecordApp.ViewModel
{
    public class RegisterVM : INotifyPropertyChanged
    {
        #region Listado de Comandos en VM y  Constructor
        //referencio el RegisterComand 
        public RegisterCommand RegisterCommand { get; set; }

        //Inciializo el register command
        public RegisterVM()
        {
            RegisterCommand = new RegisterCommand(this);
        }
        #endregion

        #region Porpiedades del VM en modo FullProp
        private User user;
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfPassword = this.ConfPassword
                };
                OnPropertyChanged("Email");
            }
        }

        private string password;


        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfPassword=this.ConfPassword
                };
                OnPropertyChanged("Password");
            }

        }

        private string confpassword;
        public string ConfPassword
        {
            get { return confpassword; }
            set
            {
                confpassword = value;
                User = new User()
                {
                    Email = this.Email,
                    Password = this.Password,
                    ConfPassword = this.ConfPassword
                };
                OnPropertyChanged("Password");
            }

        }
        #endregion

        #region Métodos y Lógica
        public void Register(User user)
        {
           User.Register(user);
        }

        #endregion

        #region INotifyPropertychanged

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }

}