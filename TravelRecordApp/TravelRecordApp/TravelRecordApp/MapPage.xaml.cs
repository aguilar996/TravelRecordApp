using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
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
                // si la variable globla de permisos es igual  a Grantd
                if(PermStatus== PermissionStatus.Granted)
                {
                        //Invocamos el mapa con la ubicación actual
                    LocationMap.IsShowingUser = true;
                }
                    else
                    {
                        await DisplayAlert("Location Issue", "We couldn't determine your location", "OK");
                    }
                }

            }
            catch(Exception e)
            {
                await DisplayAlert("Error", e.Message, "OK");
            }
        }
	}


}