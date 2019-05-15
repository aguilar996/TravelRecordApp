using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelRecordApp.Model
{
    //1.Usamos  : INotifyPropertyChanged
    //2.Agregamos using System.ComponentModel;
    //3.Generamos la interface
    //4.Agregamos SNIPPET
    public class User: INotifyPropertyChanged
    {

        //5.Hacemos PROPFULL de todas las entidades
        private string id;

        public string Id
        {
            get { return id; }
            set {
                id = value;
                OnPropertyChange("Id");
            }
        }



        private string email;

        public string Email
        {
            get { return email; }
            set { email = value;
                OnPropertyChange("Email");
            }
        }


        private string password;

        public string Password
        {
            get { return password; }
            set { password = value;
                OnPropertyChange("Password");
            }
        }

        private string confpassword;

        public string ConfPassword
        {
            get { return confpassword; }
            set
            {
                confpassword = value;
                OnPropertyChange("ConfPassword");
            }
        }

        //Interface
        public event PropertyChangedEventHandler PropertyChanged;

        public static async Task<bool> Login(string email_user, string password)
        {
            if (string.IsNullOrEmpty(email_user) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            else
            {
                try
                {

                var user = (await App.MobileService.GetTable<User>()
                    .Where(x => x.Email == email_user).ToListAsync())
                    .FirstOrDefault(); 
                if (user != null)
                {
                    App.user = user;
                    if (user.Password == password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
                }
                catch(Exception e)
                {
                    await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
                    return false;
                }

            }
        }

        public static async void Register(User user)
        {
            try
            {
            await App.MobileService.GetTable<User>().InsertAsync(user);
            await App.Current.MainPage.DisplayAlert("Success", "User Inserted correctly", "OK");
            }
            catch(Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Error", e.Message, "OK");

            }

        }

        //SNIPPET
        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
