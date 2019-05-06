using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelRecordApp.Model
{
    public class Post : INotifyPropertyChanged
    {
       // [PrimaryKey, AutoIncrement]
        //public int Id { get; set; } PARA SQLITE
       
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value;
                OnPropertyChange("Id");
                }
        }

        private string experience;

        public string Experience
        {
            get { return experience; }
            set { experience = value;
                OnPropertyChange("Experience");

                }
        }


        private string venueName;

        public string VenueName
        {
            get { return venueName; }
            set { venueName = value;
                OnPropertyChange("VenueName");
            }
        }

        private string categoryId;

        public string CategoryId
        {
            get { return categoryId; }
            set { categoryId = value;
                OnPropertyChange("CategoryId");
            }
        }

        private string categoryName;

        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value;
                OnPropertyChange("CategoryName");
            }
        }


        private string address;

        public string Address
        {
            get { return address; }
            set { address = value;
                OnPropertyChange("Address");
            }
        }


        private double latitude;

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value;
                OnPropertyChange("Latitude");
            }
        }

        private double longitud;

        public double Longitud
        {
            get { return longitud; }
            set { longitud = value;
                OnPropertyChange("Longitud");
            }
        }

        private int distance;

        public int Distance
        {
            get { return distance; }
            set { distance = value;
                OnPropertyChange("Distance");
            }
        }

        private string userId;

        public string UserId
        {
            get { return userId; }
            set {userId = value;
                OnPropertyChange("UserId");
            }
        }
         
        public event PropertyChangedEventHandler PropertyChanged;

        public static async void Insert(Post post)
        {
            await App.MobileService.GetTable<Post>().InsertAsync(post);
        }

        public static async Task<List<Post>> Read()
        {
            var posts = await App.MobileService.GetTable<Post>().Where(p => p.UserId == App.user.Id).ToListAsync();
            return posts as List<Post>;
        }

        public static Dictionary<string,int> PostCategories(List<Post> posts)
        {
            var categories = posts.OrderBy(x => x.CategoryId).Select(y => y.CategoryName).Distinct().ToList();

            Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
            foreach (var category in categories)
            {
                var count = posts.Where(x => x.CategoryName == category).ToList().Count;
                categoriesCount.Add(category, count);
            }

            return categoriesCount;
        }

        //Property Change Event setter
        private void OnPropertyChange(string propertyName)
        {
            if(PropertyChanged!=null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}
