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
            try
            {

            if(Pass.Text==PassConfirm.Text)
            {
                //register
                User user = new User()
                {
                    Email = Email.Text,
                    Password=Pass.Text
                };
                var users = await App.MobileService.GetTable<User>().ToListAsync() as List<User>;
                if (!users.Any(x => x.Email == user.Email))
                {
                    await App.MobileService.GetTable<User>().InsertAsync(user);
                    await DisplayAlert("Correct", "Succesfully registered", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "Already registered", "OK");

                }

            }
            else
            {
              await DisplayAlert("Error", "Passwords must match","OK");
            }
            }
            catch(Exception ex)
            {

            }
        }
 
    }
}