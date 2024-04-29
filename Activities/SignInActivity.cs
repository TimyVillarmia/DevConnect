using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.Nfc;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using DevConnect.Common;
using Firebase.Auth;
using Google.Android.Material.Button;
using Google.Android.Material.TextField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevConnect.Activities
{
    [Activity(Label = "SignInActivity")]
    public class SignInActivity : Activity, IOnCompleteListener
    {
        TextInputLayout textInputLayout_email;
        TextInputLayout textInputLayout_pass;
        MaterialButton materialButton_signIn;
        TextView textView_create;

        FirebaseAuth auth;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.signin_layout);
            // Create your application here
            auth = FirebaseRepository.getFirebaseAuth();

            textInputLayout_email = FindViewById<TextInputLayout>(Resource.Id.textInputLayout_email);
            textInputLayout_pass = FindViewById<TextInputLayout>(Resource.Id.textInputLayout_pass);
            materialButton_signIn = FindViewById<MaterialButton>(Resource.Id.materialButton_signIn);
            textView_create = FindViewById<TextView>(Resource.Id.textView_create);

            materialButton_signIn.Click += MaterialButton_signIn_Click;
            textView_create.Click += TextView_create_Click;


            textInputLayout_email.EditText.TextChanged += delegate { ValidateField(textInputLayout_email); };
            textInputLayout_pass.EditText.TextChanged += delegate { ValidateField(textInputLayout_pass); };
        }

        private void TextView_create_Click(object sender, EventArgs e)
        {
            Intent create = new Intent(this, typeof(SignUpActivity));
            StartActivity(create);
        }

        private void ValidateField(TextInputLayout field)
        {


            if (string.IsNullOrEmpty(field.EditText?.Text))
            {
                field.Error = "Must not be empty.";
                materialButton_signIn.Clickable = false;
                return;

            }

            if (field.Id == textInputLayout_email.Id)
            {
                bool isEmail = Regex.IsMatch(field.EditText?.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

                if (!isEmail)
                {
                    textInputLayout_email.Error = "Must be a valid email address";
                    materialButton_signIn.Clickable = false;
                    return;
                }

            }


            //textFieldFullname.ErrorEnabled = false;
            textInputLayout_email.ErrorEnabled = false;
            materialButton_signIn.Clickable = true;

        }


        [Obsolete]
        public override void OnBackPressed()
        {
            Toast.MakeText(ApplicationContext, "You're about to exit the app", ToastLength.Long).Show();
        }

        private void MaterialButton_signIn_Click(object sender, EventArgs e)
        {

            string email = textInputLayout_email.EditText?.Text.Trim();
            string pass = textInputLayout_pass.EditText?.Text.Trim();

            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(pass))
            {
                //textFieldFullname.Error = "Must not be empty.";
                textInputLayout_email.Error = "Must not be empty.";
                textInputLayout_pass.Error = "Must not be empty.";

                return;
            }

            auth.SignInWithEmailAndPassword(email, pass)
                              .AddOnCompleteListener(this, this);

        }

        public void SignInSucces()
        {
            Intent Home = new Intent(this, typeof(MainActivity));
            StartActivity(Home);
            Finish();
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                Toast.MakeText(this, "Login was successful!", ToastLength.Short).Show();
                SignInSucces();
                Finish();
            }
            else
            {
                try
                {
                    throw task.Exception;
                }
                catch (FirebaseAuthWeakPasswordException e)
                {
                    Toast.MakeText(this, e.Message, ToastLength.Short).Show();
                }
                catch (FirebaseAuthInvalidCredentialsException e)
                {
                    Toast.MakeText(this, e.Message, ToastLength.Short).Show();

                }
                catch (FirebaseAuthUserCollisionException e)
                {
                    Toast.MakeText(this, e.Message, ToastLength.Short).Show();

                }
                catch (Exception e)
                {
                    Toast.MakeText(this, e.Message, ToastLength.Short).Show();

                }
            }

        }

  
    }
}