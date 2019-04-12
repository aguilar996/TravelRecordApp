using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void Login_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(User.Text)|| string.IsNullOrEmpty(Pass.Text))
            {

            }
            else
            {
                Navigation.PushAsync(new HomePage());
            }
        }
    }
}
