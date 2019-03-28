using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;

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

            //Base de datos SQLite path para andorid
            string dbName = "travel_db.sqlite"; //db name
            //en android se guarda en la "Special Folder" Personal
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            // Cobinamos el relative path con el nombre del archivo
            string fullPath = Path.Combine(folderPath, dbName);
            //paso el fullPath al constructor nuevo
            LoadApplication(new App(fullPath));
        }
    }
}