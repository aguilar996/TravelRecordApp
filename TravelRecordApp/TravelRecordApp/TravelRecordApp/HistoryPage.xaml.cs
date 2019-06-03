using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryPage : ContentPage
	{
        HistoryVM viewModel;
		public HistoryPage ()
		{
			InitializeComponent ();
            viewModel = new HistoryVM();
            BindingContext = viewModel;
		}
        #region deprecated
        //ANTIGUO CON CLOSE 
        ////Metodo que hace override al aprecer el Tab
        ////Lo usamos para leer de la base lo que sea que deba mostrarse en este tab
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();//No borrar
        //    //coneción a la base
        //    SQLiteConnection db = new SQLiteConnection(App.DbLocation);
        //    //Creación de tabla (si ya existe la pasa por alto)
        //    db.CreateTable<Post>();
        //    //Guardar resultados toList()
        //   var post= db.Table<Post>().ToList();
        //    //Cerramos conexión
        //    db.Close();
        //}
        #endregion

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //coneción a la base SQLite
            //using (SQLiteConnection db = new SQLiteConnection(App.DbLocation))
            //{
            //    //Creación de tabla (si ya existe la pasa por alto)
            //    db.CreateTable<Post>();
            //    //Guardar resultados toList()
            //    var post = db.Table<Post>().ToList();
            //    //Pasamos la lista  aun objeto ListView
            //    PostListView.ItemsSource = post;
            //}
            viewModel.UpdatePosts();
            //Refrescamos local y luego en nube 
            await AzureAppServiceHelper.SyncAsync();
            //PostListView.ItemsSource = posts;
        }

        //evento de elemento seleccionado
        private void PostListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var SelectedItem = PostListView.SelectedItem as Post;
            if(SelectedItem!=null)
            {
                Navigation.PushAsync(new PostDetailPage(SelectedItem));
            }
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var post = (Post)(((MenuItem)sender).CommandParameter);
            viewModel.DeletePost(post);

            viewModel.UpdatePosts();

        }

        private async void PostListView_Refreshing(object sender, EventArgs e)
        {
            viewModel.UpdatePosts();
            //Refrescamos local y luego en nube 
            await AzureAppServiceHelper.SyncAsync();
            //Desaparecer el icono de refresh 2 formas
            //Forma 1 hay q convertir el Update post en task bool para que se llame cuando se hayan refrescado los posts
            // PostListView.IsRefreshing = false;
            //Forma 2
            PostListView.EndRefresh();

        }
    }
}