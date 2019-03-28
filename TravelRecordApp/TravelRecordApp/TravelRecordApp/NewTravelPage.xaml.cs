using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TravelRecordApp.Model;
using SQLite;

namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTravelPage : ContentPage
	{
		public NewTravelPage ()
		{
			InitializeComponent ();
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
        private void Save_Clicked(object sender, EventArgs e)
        {
            //creamos objeto con los entrys
            Post post = new Post()
            {
                Experience = ExperienceEntry.Text
            };
            //Creamos nueva conexión
            using (SQLiteConnection db = new SQLiteConnection(App.DbLocation)) 
            {
              // Creamos taba(Si ya existe se obiva)
             db.CreateTable<Post>();
             //Insertamos objeto
             int rows= db.Insert(post); 
                if(rows>0)
                {
                     DisplayAlert("Success", "Experience succesfully saved","OK");
                }
                else
                {
                     DisplayAlert("Error", "Something went wrong","OK");
                }
            }
        }
    }
}