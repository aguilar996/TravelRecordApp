using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        //Para Two Way comunication View con Viewmodel
        //Creamos un nuevo usuario global
        User user;
        RegisterVM viewModel;
        public RegisterPage()
        {
            InitializeComponent();
            //lo incializamos
            user = new User();
            ////seteamos el layout entero con su bInding Context apuntando a ese usuario
            //containerStackLayout.BindingContext=user;
            BindingContext = viewModel;
        }

        //private async void Register_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {

        //    if(Pass.Text==PassConfirm.Text)
        //    {
        //            #region Old Object now in USER
        //            //register
        //            //User user = new User()
        //            //{
        //            //    Email = Email.Text,
        //            //    Password=Pass.Text
        //            //};
        //            #endregion

        //            //  var users = await App.MobileService.GetTable<User>().ToListAsync() as List<User>;
        //            //  if (!users.Any(x => x.Email == user.Email))
        //            //  {
        //            User.Register(user);
        //            await DisplayAlert("Correct", "Succesfully registered", "OK");
        //            await Navigation.PopAsync();
        //      //  }
        //        //else
        //        //{
        //        //    await DisplayAlert("Error", "Already registered", "OK");
        //        //}

        //    }
        //    else
        //    {
        //      await DisplayAlert("Error", "Passwords must match","OK");
        //    }
        //    }
        //    catch(Exception ex)
        //    {

        //    }
        //}
 
    }
}