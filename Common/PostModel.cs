using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevConnect.Common
{
    public class PostModel
    {
        public string poster_name { get; set; }
        public string poster_handler { get; set; }
        public string post_time { get; set; }
        public string post_description { get; set; }
        public string post_image { get; set; }

        public PostModel(string poster, string handler, string time, string description, string image)
        {
            this.poster_name = poster;
            this.poster_handler = handler;
            this.post_time = time;
            this.post_description = description;
            this.post_image = image;
        }

    }
}