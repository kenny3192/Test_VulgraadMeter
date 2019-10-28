using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.InputMethodServices;
using System;

namespace Test_VulgraadMeter
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        int count = 1;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button buttonBin = FindViewById<Button>(Resource.Id.MyButton);
            buttonBin.Click += Button_Click;


            EditText editText = FindViewById<EditText>(Resource.Id.editText1);

            //buttonBin.Click += delegate { buttonBin.Text = editText.Text; };

                //string.Format("{0} clicks!", count++); };
        }

        private void Button_Click(object sender, EventArgs e)
        {
            SetContentView(Resource.Layout.Vulgraad);
        }


        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
    }
}