using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var assembly = typeof(MainPage);
            iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.plane.png", assembly);
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(User.Text)|| string.IsNullOrEmpty(Pass.Text))
            {

            }
            else
            {
                var user =  (await App.MobileService.GetTable<User>().Where(
                    x=>x.Email == User.Text).ToListAsync()).FirstOrDefault();
                if(user!=null)
                {
                    App.user = user;
                    if (user.Password==Pass.Text)
                    {
                        await Navigation.PushAsync(new HomePage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Email or Password Incorrect", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "Error logging you In", "Ok");
                }

            }
        }

        private void RegisterUserButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
