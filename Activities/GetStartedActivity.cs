using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Google.Android.Material.Button;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevConnect.Activities
{
    [Activity(Label = "GetStartedActivity")]
    public class GetStartedActivity : Activity
    {
        MaterialButton materialButton_getStarted;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.getstarted_layout);
            // Create your application here

            materialButton_getStarted = FindViewById<MaterialButton>(Resource.Id.materialButton_getStarted);

            materialButton_getStarted.Click += MaterialButton_getStarted_Click;
        }

        private void MaterialButton_getStarted_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(Application.Context, typeof(SignInActivity)));
            Finish();
        }

        [Obsolete]
        public override void OnBackPressed()
        {
            Toast.MakeText(ApplicationContext, "You're about to exit the app", ToastLength.Long).Show();
        }
    }
}