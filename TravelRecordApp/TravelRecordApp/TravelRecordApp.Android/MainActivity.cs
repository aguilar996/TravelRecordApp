using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Xamarin.Forms.Maps;
using Plugin.Permissions;
using Plugin.CurrentActivity;
namespace TravelRecordApp.Droid
{
    [Activity(Label = "TravelRecordApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //metodo init para maps
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            //Init de permisos
             CrossCurrentActivity.Current.Init(this, savedInstanceState);
            //Base de datos SQLite path para android
            string dbName = "travel_db.sqlite"; //db name
            //en android se guarda en la "Special Folder" Personal
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            // Cobinamos el relative path con el nombre del archivo
            string fullPath = Path.Combine(folderPath, dbName);
            //paso el fullPath al constructor nuevo
            LoadApplication(new App(fullPath));
        }

        //uso de permisos con Plugin.Permissions para que andorid no se caiga con el mapa
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }


}