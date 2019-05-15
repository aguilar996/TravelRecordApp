using Microsoft.WindowsAzure.MobileServices;
using System;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TravelRecordApp
{
    public partial class App : Application
    {
        //Ubicación de la base de datos SQLite-net-PCL
        public static string DbLocation=string.Empty;
        //Referencia a app client de Azure
        public static MobileServiceClient MobileService =
        new MobileServiceClient("https://travelrecord.azurewebsites.net");

        public static User user = new User();
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }
        //Nuevo Constructor
        public App(string db)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            //asignamos la dirección que recibe el constructor
            DbLocation = db;

        }
        
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
