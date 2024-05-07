using Android.App;
using Android.Content;
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
    public class Constant
    {
        public static List<PostModel> GetPostModels()
        {
            // create an ArrayList of type Employee class
            List<PostModel> feedList
                = new List<PostModel>();
            PostModel post1 = new PostModel(
                "Timy Villarmia",
                "@tmyyy",
                "1 year ago",
                Resource.String.lorem.ToString(),
                "https://miro.medium.com/v2/resize:fit:600/1*2Xx6tr_6jtJMFsdW7r-VMA.jpeg");

            feedList.Add(post1);


            return feedList;
        }
    }
}