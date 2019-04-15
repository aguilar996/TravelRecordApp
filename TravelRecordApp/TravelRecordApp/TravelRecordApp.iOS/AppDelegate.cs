using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Foundation;
using Microsoft.WindowsAzure.MobileServices;
using UIKit;

namespace TravelRecordApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            //referencia INIT a servicio Azure
            CurrentPlatform.Init();
            //preparamos a iOS para usar XAmarin Forms Maps
            Xamarin.FormsMaps.Init();
            //Base de datos SQLite path para iPhone
            string dbName = "travel_db.sqlite"; //db name
            //en iPhone no se guarda en personal sino en el mismo direcotrio pero en Library
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),"..", "Library");
            //Cobinamos el relative path con el nombre del archivo
            string fullPath = Path.Combine(folderPath,dbName);
            //paso el fullPath al constructor nuevo
            LoadApplication(new App(fullPath));

            return base.FinishedLaunching(app, options);
        }
    }
}
