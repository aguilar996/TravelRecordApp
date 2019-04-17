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
                var postTable = await App.MobileService.GetTable<Post>()
                .Where(p => p.Id == App.user.Id).ToListAsync();
 
                //var categoriesDeprecated = (from p in postTable
                //                  orderby p.CategoryId
                //                  select p.CategoryName).Distinct().ToList();
            var categories = postTable.OrderBy(x => x.CategoryId).Select(y=>y.CategoryName).Distinct().ToList();

                Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
                foreach (var category in categories)
                {
                    //var countDeprecated = (from post in postTable 
                    //where post.CategoryName == category 
                    //  select post).ToList().Count();

                    var count = postTable.Where(x => x.CategoryName == category).ToList().Count;
                    categoriesCount.Add(category, count);
                }
                    categoriesListView.ItemsSource = categoriesCount;
                    postCountLabel.Text = postTable.Count.ToString();
                

            //}
        }
    }
}