﻿using SQLite;
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
    public partial class PostDetailPage : ContentPage
    {
        Post selectedPostGlobal;
        public PostDetailPage(Post selectedPost)
        {
            InitializeComponent();
            //asigno a la variable global el alor del item que regresa 
            //en el método, para así usarla en update y delete
            selectedPostGlobal = selectedPost;
            //asigno el texto de listado, al entry en pantalla.
            ExperienceEntry.Text = selectedPostGlobal.Experience;
        }

        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            selectedPostGlobal.Experience = ExperienceEntry.Text;

            using (SQLiteConnection db = new SQLiteConnection(App.DbLocation))
            {
                //ver si ya existe la tabla
                db.CreateTable<Post>();
                //updateamos objeto
                int rows = db.Update(selectedPostGlobal);
                if (rows > 0)
                {
                    bool result = await DisplayAlert("Success", "Experience succesfully Updated", "OK", "Cancel");
                    if (result) { await Navigation.PopAsync(); }


                }
                else
                {
                    var result = await DisplayAlert("Error", "Something went wrong", "OK", "cancel");

                }
            }
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection db = new SQLiteConnection(App.DbLocation))
            {
                //ver si ya existe la tabla
                db.CreateTable<Post>();
                //borramos objeto
                int rows = db.Delete(selectedPostGlobal);
                if (rows > 0)
                {
                    bool result = await DisplayAlert("Success", "Experience succesfully Deleted", "OK", "Cancel");
                    if (result) { await Navigation.PopAsync(); }


                }
                else
                {
                    var result = await DisplayAlert("Error", "Something went wrong", "OK", "cancel");

                }
            }
        }
    }
}