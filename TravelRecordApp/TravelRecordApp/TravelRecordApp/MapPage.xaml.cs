using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms.Maps;

namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
        //Variable local que me indica si hay permisos o no
        private bool hasLocationPermission;
		public MapPage ()
		{
       
           
                InitializeComponent();
                GetPermissions();
            

        }

        //Método que checkea si hay permisos de localizacion
        private async void GetPermissions()
        {
            try
            {
                //Busca el estado del permiso, en este caso WhenInUse
            var PermStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
                //Check si esta Granted o no
            if(PermStatus!= PermissionStatus.Granted)
            {
                    //Check si deberiamos perdir permiso o no ANDROID
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                    {
                        await DisplayAlert("Need your Location", "We need to acces your location", "OK");
                    }
                    //Listamos los permisos actuales en una varible
                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
                        //Si el listado contiene ese permiso...
                    if(results.ContainsKey(Permission.LocationWhenInUse))
                    { 
                            //... alamcenamos el status del permiso en a variable glabal
                    PermStatus = results[Permission.LocationWhenInUse];
                    }
            }
                // si la variable globla de permisos es igual  a Grantd
                if (PermStatus == PermissionStatus.Granted)
                {
                    //Invocamos el mapa con la ubicación actual
                    LocationMap.IsShowingUser = true;
                    //si tengo permiso afecto tb a la variable global
                    hasLocationPermission = true;
                    //Metodo de ubucacion acutal si es que tengo permiso
                    GetLocation();
            
                }
                    else
                    {
                        await DisplayAlert("Location Issue", "We couldn't determine your location", "OK");
                    }
            }
            catch(Exception e)
            {
                await DisplayAlert("Error", e.Message, "OK");
            }
        }

        // Metodo de invocacion del tab que busca la ubicacion del dispositivo
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if(hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                locator.PositionChanged += Locator_PositionChanged;
                await locator.StartListeningAsync(TimeSpan.Zero, 100);
            }
            GetLocation();

            using (SQLiteConnection db = new SQLiteConnection(App.DbLocation))
            {
                //Creación de tabla (si ya existe la pasa por alto)
                db.CreateTable<Post>();
                //Guardar resultados toList()
                var posts = db.Table<Post>().ToList();
                DisplayInMap(posts);
            }

        }

        private void DisplayInMap(List<Post> posts)
        {
            foreach(var post in posts)
            {
                try
                {

                var position = new Xamarin.Forms.Maps.Position(post.latitude,post.longitud);
                var pin = new Pin()
                {
                    Type = PinType.SavedPin,
                    Position = position,
                    Label = post.VenueName,
                    Address = post.Address
                };
                LocationMap.Pins.Add(pin);
                }
                catch(NullReferenceException Nre)
                {

                }
                catch(Exception e)
                {

                }

            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CrossGeolocator.Current.StopListeningAsync();
            CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged;
        }

        //metodo asynchrono que llama la plugin de geolocaclizacion
        private async void GetLocation()
        {
            if(hasLocationPermission)
            {
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
                MoveMap(position);
            }
                
        }

        void Locator_PositionChanged(Object sender, PositionEventArgs e)
        {
            MoveMap(e.Position);
        }
        //Funcion que se llama para mover el mapa se llama cuando cambia la posion y cuando se comsulta el tab de mapa
        private void MoveMap(Plugin.Geolocator.Abstractions.Position position)
        {
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);
            LocationMap.MoveToRegion(span);
        }
    }


}