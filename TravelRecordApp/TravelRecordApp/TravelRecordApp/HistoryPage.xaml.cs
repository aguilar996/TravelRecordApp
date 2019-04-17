using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryPage : ContentPage
	{
		public HistoryPage ()
		{
			InitializeComponent ();
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
            base.OnAppearing();//No borrar

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

            //Conexion a la nube
            var posts = await App.MobileService.GetTable<Post>()
                .Where(x => x.userId == App.user.Id).ToListAsync();
                PostListView.ItemsSource = posts;
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
    }
}