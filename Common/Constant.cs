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
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris at finibus sem, malesuada placerat mauris." +
                "Curabitur consectetur augue eget dui feugiat eleifend. Fusce pretium",
                "https://miro.medium.com/v2/resize:fit:600/1*2Xx6tr_6jtJMFsdW7r-VMA.jpeg");

            feedList.Add(post1);

            PostModel post2 = new PostModel(
                "Timy Villarmia",
                "@tmyyy",
                "1 year ago",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris at finibus sem, malesuada placerat mauris." +
                "Curabitur consectetur augue eget dui feugiat eleifend. Fusce pretium",
                "https://www.thesprucepets.com/thmb/nKNaS4I586B_H7sEUw9QAXvWM_0=/2121x0/filters:no_upscale():strip_icc()/GettyImages-135630198-5ba7d225c9e77c0050cff91b.jpg");

            feedList.Add(post2);

            PostModel post3 = new PostModel(
                "Timy Villarmia",
                "@tmyyy",
                "1 year ago",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris at finibus sem, malesuada placerat mauris." +
                "Curabitur consectetur augue eget dui feugiat eleifend. Fusce pretium",
                "https://media.istockphoto.com/id/485998252/photo/raccoon.jpg?s=612x612&w=0&k=20&c=cSQE-6Js-3n3-sa_gXaC_PygZi-mqyn4sktAxw-6QiE=");

            feedList.Add(post3);

            PostModel post4 = new PostModel(
                "Timy Villarmia",   
                "@tmyyy",
                "1 year ago",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris at finibus sem, malesuada placerat mauris." +
                "Curabitur consectetur augue eget dui feugiat eleifend. Fusce pretium",
                "https://t4.ftcdn.net/jpg/02/21/13/29/360_F_221132937_6X32xmuAeHgS7x6aYshPEnkuIrswoBQk.jpg");

            feedList.Add(post4);


            return feedList;
        }
    }
}