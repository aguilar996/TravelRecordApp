using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TravelRecordApp.Model;

namespace TravelRecordApp.ViewModel
{
    public class HistoryVM
    {
        //Nueva lista Observable colletion que dispara eventos de cambios
        public ObservableCollection<Post> Posts { get; set; }

        //Inicializo el viewModel con un nuevo objeto Posts
        public HistoryVM()
        {
            Posts = new ObservableCollection<Post>();
        }

        //añado la funcionalidad del controlador qe hace el update
        public async void UpdatePosts()
        {
            List<Post> posts = await Post.Read();
            if(Posts!=null)
            {
                Posts.Clear();
                foreach (var post in posts)
                {
                   Posts.Add(post);
                }
            }
        }
    }
}
