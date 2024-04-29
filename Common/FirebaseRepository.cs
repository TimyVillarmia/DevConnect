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
using Firebase.Firestore;

namespace DevConnect.Common
{
    public class FirebaseRepository
    {
        static FirebaseApp app;
        public static FirebaseAuth getFirebaseAuth()
        {
            //app instance
            app = FirebaseApp.InitializeApp(Application.Context);

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
        public static FirebaseFirestore GetFirebaseFirestore()
        {
            //app instance
            app = FirebaseApp.InitializeApp(Application.Context);

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

            return FirebaseFirestore.GetInstance(app);
        }
    }
}