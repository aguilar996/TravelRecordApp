using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TravelRecordApp.Model;
using SQLite;
using Plugin.Geolocator;
using TravelRecordApp.ViewModel;

namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTravelPage : ContentPage
	{
        NewTravelVM viewModel;
		public NewTravelPage ()
		{
			InitializeComponent ();
             viewModel = new NewTravelVM();
             BindingContext = viewModel;
             //containerStackLayout.BindingContext = viewModel.Post;
		}
        //sobre escribo el metodo on appear para que consulte cada vez que aparece la página de nuevo viaje
        protected override async void OnAppearing()
        {
            base.OnAppearing(); 
            //Objeto locator para obtener el GPS
            var locator = CrossGeolocator.Current;
            //objeto posicion para obtener posición actual
            var position = await locator.GetPositionAsync();
            //.NET Standart
            //llamamos a la logica de Venues y le enviamos Logitud y latitud actual


            //MVVM
            List<Venue> venues = await  Venue.GetVenues(position.Latitude, position.Longitude) ;
            venueListView.ItemsSource = venues;
        }

        #region deprecated
        //ANTIGUO CON CLOSE
        //private void Save_Clicked(object sender, EventArgs e)
        //{
        //    //creamos objeto con los entrys
        //    Post post = new Post()
        //    {
        //        Experience = ExperienceEntry.Text
        //    };
        //    //Creamos nueva conexión
        //    SQLiteConnection db = new SQLiteConnection(App.DbLocation);
        //    //Creamos taba (Si ya existe se obiva)
        //    db.CreateTable<Post>();
        //    //Insertamos objeto
        //    db.Insert(post);
        //    //Cerramos conexión
        //    db.Close();
        //}
        #endregion
        //private  async void Save_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //recupero el objeto seleccionado con:
        //        //var selectedVenue = venueListView.SelectedItem as Venue;
        //        //recuoperamos la primera categoria de la lista de categorias
              
        //        //};

        //        #region Creamos nueva conexión
        //        //using (SQLiteConnection db = new SQLiteConnection(App.DbLocation))
        //        //{
        //        //    // Creamos taba(Si ya existe se obiva)
        //        //    db.CreateTable<Post>();
        //        //    //Insertamos objeto
        //        //    int rows = db.Insert(post);
        //        //    if (rows > 0)
        //        //    {
        //        //        bool result = await DisplayAlert("Success", "Experience succesfully Saved", "OK", "Cancel");
        //        //        if (result) { await Navigation.PopAsync(); }


        //        //    }
        //        //    else
        //        //    {
        //        //        var result = await DisplayAlert("Error", "Something went wrong", "OK", "cancel");

        //        //    }

        //        //}
        //        #endregion

        //        ////AZURE db
        //        //await App.MobileService.GetTable<Post>().InsertAsync(post);

        //        //MVVM
        //        Post.Insert(post);
        //        await DisplayAlert("Success", "Experience succesfully Inserted", "OK");
        //        await Navigation.PopAsync();
        //    }
        //    catch(NullReferenceException Nre)
        //    {
        //        await DisplayAlert("Failure", "Experience failed to insert", "OK");
        //    }
        //    catch (Exception ex)
        //    {
        //        await DisplayAlert("Failure", "Experience failed to insert", "OK");
        //    }
          
        //}

        private void Delete_Clicked(object sender, EventArgs e)
        {

        }
    }
}