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

namespace DevConnect.Activities
{
    [Activity(Label = "GetStartedActivity")]
    public class GetStartedActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.getstarted_layout);
            // Create your application here
        }

        [Obsolete]
        public override void OnBackPressed()
        {
            Toast.MakeText(ApplicationContext, "You're about to exit the app", ToastLength.Long).Show();
        }
    }
}