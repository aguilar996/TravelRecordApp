using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
    
        MainVM viewModel;
        public MainPage()
        {
            InitializeComponent(); 
            viewModel = new MainVM();
            BindingContext = viewModel; 
            //Imagen
            var assembly = typeof(MainPage);
            iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.plane.png", assembly);
             
        }

        //private async void Login_Clicked(object sender, EventArgs e)
        //{
        //    bool canLogin = await Model.User.Login(User.Text,Pass.Text);
        //    if (canLogin)
        //    { await Navigation.PushAsync(new HomePage()); }
        //    else
        //    { await DisplayAlert("Error", "Email or Password Incorrect", "Ok"); }

        //}

        private void RegisterUserButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
