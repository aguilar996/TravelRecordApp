using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void Register_Clicked(object sender, EventArgs e)
        {
            if(Pass.Text==PassConfirm.Text)
            {
                //register
                User user = new User()
                {
                    Email = Email.Text,
                    Password=Pass.Text
                };
                await App.MobileService.GetTable<User>().InsertAsync(user);

            }
            else
            {
              await DisplayAlert("Error", "Passwords must match","OK");
            }
        }
 
    }
}