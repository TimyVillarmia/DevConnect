using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DevConnect.Common;
using Firebase.Auth;
using Firebase.Firestore;
using Google.Android.Material.Button;
using Google.Android.Material.TextField;
using Java.Util;
using Org.Apache.Http.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace DevConnect.Activities
{
    [Activity(Label = "SignUpActivity")]
    public class SignUpActivity : Activity, IOnCompleteListener
    {
        TextInputLayout textInputLayout_createName;
        TextInputLayout textInputLayout_createEmail;
        TextInputLayout textInputLayout_createPass;
        TextInputLayout textInputLayout_confirmpass;
        MaterialButton materialButton_signUp;
        TextView textView_login;

        FirebaseAuth auth;
        FirebaseFirestore db;
   

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.signup_layout);
            // Create your application here
            auth = FirebaseRepository.getFirebaseAuth();
            db = FirebaseRepository.GetFirebaseFirestore();


            textInputLayout_createName = FindViewById<TextInputLayout>(Resource.Id.textInputLayout_createName);
            textInputLayout_createEmail = FindViewById<TextInputLayout>(Resource.Id.textInputLayout_createEmail);
            textInputLayout_createPass = FindViewById<TextInputLayout>(Resource.Id.textInputLayout_createPass);
            textInputLayout_confirmpass = FindViewById<TextInputLayout>(Resource.Id.textInputLayout_confirmpass);
            materialButton_signUp = FindViewById<MaterialButton>(Resource.Id.materialButton_signUp);
            textView_login = FindViewById<TextView>(Resource.Id.textView_login);


            textView_login.Click += TextView_login_Click; ;
            materialButton_signUp.Click += MaterialButton_signUp_Click; ;


            textInputLayout_createName.EditText.TextChanged += delegate { ValidateField(textInputLayout_createName); };
            textInputLayout_createEmail.EditText.TextChanged += delegate { ValidateField(textInputLayout_createEmail); };
            textInputLayout_createPass.EditText.TextChanged += delegate { ValidateField(textInputLayout_createPass); };
            textInputLayout_confirmpass.EditText.TextChanged += delegate { ValidateField(textInputLayout_confirmpass); };
        }

        private void MaterialButton_signUp_Click(object sender, EventArgs e)
        {
            string fullname = textInputLayout_createName.EditText?.Text;
            string email = textInputLayout_createEmail.EditText?.Text;
            string pass = textInputLayout_createPass.EditText?.Text;
            string confirmpass = textInputLayout_confirmpass.EditText?.Text;

            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(pass) ||
                string.IsNullOrEmpty(fullname))
            {
                textInputLayout_createName.Error = "Must not be empty.";
                textInputLayout_createEmail.Error = "Must not be empty.";
                textInputLayout_createPass.Error = "Must not be empty.";
                textInputLayout_confirmpass.Error = "Must not be empty.";
                return;
            }


            auth.CreateUserWithEmailAndPassword(email, pass)
                  .AddOnCompleteListener(this, this);







        }

        public void StartSignInActivity()
        {
            Intent login = new Intent(this, typeof(SignInActivity));
            StartActivity(login);
            Finish();
        }

        public void OnComplete(Task task)
        {
            if (task.IsSuccessful)
            {
                HashMap userMap = new HashMap();
                userMap.Put("fullname", textInputLayout_createName.EditText?.Text);

                DocumentReference userRef = db.Collection("users").Document(auth.CurrentUser.Uid);
                userRef.Set(userMap);

                Toast.MakeText(this, "Registration was successful!", ToastLength.Short).Show();
                StartSignInActivity();
            }
            else
            {
                Toast.MakeText(this, task.Exception.Message, ToastLength.Short).Show();
            }
        }

        private void TextView_login_Click(object sender, EventArgs e)
        {
            StartSignInActivity();
        }



        private void ValidateField(TextInputLayout field)
        {


            if (string.IsNullOrEmpty(field.EditText?.Text))
            {
                field.Error = "Must not be empty.";
                materialButton_signUp.Clickable = false;
                return;

            }
            if (field.Id == textInputLayout_createName.Id)
            {
                if (field.EditText?.Text.Length < 4)
                {
                    textInputLayout_createName.Error = "Name too short. Please enter at least 4 characters.";
                    materialButton_signUp.Clickable = false;
                    return;
                }

            }
            if (field.Id == textInputLayout_createEmail.Id)
            {
                bool isEmail = Regex.IsMatch(field.EditText?.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

                if (!isEmail)
                {
                    textInputLayout_createEmail.Error = "Must be a valid email address";
                    materialButton_signUp.Clickable = false;
                    return;
                }

            }
            if (field.Id == textInputLayout_createPass.Id)
            {

                if (field.EditText?.Text.Length < 6)
                {
                    textInputLayout_createPass.Error = "Password should be at least 6 characters.";
                    materialButton_signUp.Clickable = false;
                    return;
                }



            }
            if (field.Id == textInputLayout_confirmpass.Id)
            {

                if (field.EditText?.Text != textInputLayout_confirmpass.EditText?.Text)
                {
                    textInputLayout_confirmpass.Error = "Passwords don't match.";
                    materialButton_signUp.Clickable = false;
                    return;
                }


            }

            textInputLayout_createName.ErrorEnabled = false;
            textInputLayout_createEmail.ErrorEnabled = false;
            textInputLayout_createPass.ErrorEnabled = false;
            textInputLayout_confirmpass.ErrorEnabled = false;
            materialButton_signUp.Clickable = true;

        }
    }
}