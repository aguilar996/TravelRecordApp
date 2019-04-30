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
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
			InitializeComponent ();
            
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //using (SQLiteConnection db = new SQLiteConnection(App.DbLocation))  
            //{
            //SQLlite
            //var postTable = db.Table<Post>().ToList();
            //Azure
            var postTable = await Post.Read();
            

                    //var categoriesDeprecated = (from p in postTable
                    //                  orderby p.CategoryId
                    //                  select p.CategoryName).Distinct().ToList();
                    var categoriesCount = Post.PostCategories(postTable);
                    categoriesListView.ItemsSource = categoriesCount;
                    postCountLabel.Text = postTable.Count.ToString();
                

            //}
        }
    }
}