using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
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
        //tabla para offline synching with the cloud
        public static IMobileServiceSyncTable<Post> postsTable;
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
            //el data store necesita la dirección de la bdd en el celular
            var store = new MobileServiceSQLiteStore(db);
            //definición de la tabla en el mobile Service
            store.DefineTable<Post>();
            //Contexto de la tabla
            MobileService.SyncContext.InitializeAsync(store);
            //Metodo que permite leer a tabla de local y si se puede de la nube
            postsTable = MobileService.GetSyncTable<Post>();
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
