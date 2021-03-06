﻿using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
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

        private Venue venue;
        [JsonIgnore]
        public Venue Venue

        {
            get { return venue; }
            set { venue = value;
              
                if(venue.categories!=null)
                {
                var firstCat = value.categories.FirstOrDefault();

                if(firstCat!=null)
                    {
                    CategoryId = firstCat.id;
                    CategoryName = firstCat.name;
                    }
                }
                if(Venue.location!=null)
                {
                    Latitude = value.location.lat;
                    Longitud = value.location.lng;
                   Address = value.location.address;
                   Distance = value.location.distance;
                }
              
               VenueName = value.name;
               UserId = App.user.Id;
                OnPropertyChange("Venue");
            }
        }


        private DateTimeOffset createdat;

        public DateTimeOffset CREATEDAT
        {
            get { return createdat; }
            set
            {
                createdat = value;
                OnPropertyChange("CREATEDAT");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static async void Insert(Post post)
        {
            //Nube
            // await App.MobileService.GetTable<Post>().InsertAsync(post);
            //Local + Nube
            await App.postsTable.InsertAsync(post);
            await App.MobileService.SyncContext.PushAsync();
        }

        public static async Task<bool> Delete(Post post)
        {
            try
            {
                //Nube
                //  await App.MobileService.GetTable<Post>().DeleteAsync(post);
                //Local + Nube
                await App.postsTable.DeleteAsync(post);
                await App.MobileService.SyncContext.PushAsync();
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static async Task<List<Post>> Read()
        {
            //Nube
            //var posts = await App.MobileService.GetTable<Post>().Where(p => p.UserId == App.user.Id).ToListAsync();

            //Local + Nube
            var posts = await App.postsTable.Where(p => p.UserId == App.user.Id).ToListAsync();

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
