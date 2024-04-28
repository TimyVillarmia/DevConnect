using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Firebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevConnect.Common
{
    public class FirebaseRepository
    {

        public static FirebaseAuth getFirebaseAuth()
        {
            //app instance
            var app = FirebaseApp.InitializeApp(Application.Context);

            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                   .SetProjectId("devconnect-4f483")
                   .SetApplicationId("1:1092250463743:android:0904b463244fb394754bca")
                   .SetApiKey("AIzaSyDHJDgbvfKzVg7Psh8sBg0WsSuYiWIz3RQ")
                   .SetStorageBucket("devconnect-4f483.appspot.com")
                   .Build();

                app = FirebaseApp.InitializeApp(Application.Context, options);

            }

            return FirebaseAuth.GetInstance(app);

        }
    }
}