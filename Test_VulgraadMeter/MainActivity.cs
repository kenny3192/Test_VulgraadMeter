using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.InputMethodServices;
using System;
using Android.Views;

namespace Test_VulgraadMeter
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText editText;
        Vulgraad vulgraad = new Vulgraad();
        Button buttonBin;
        int count = 0;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            

            editText = FindViewById<EditText>(Resource.Id.editText1);
            
        }

        public override void OnContentChanged()
        {
            if(count == 1)
            {
                View vulgraad = FindViewById<View>(Resource.Layout.Vulgraad);
                SetContentView(vulgraad);
                count = 0;
            }
            else
            {
                buttonBin = FindViewById<Button>(Resource.Id.MyButton);

                buttonBin.Click += Button_Click;
            }
        }



        public override void OnBackPressed()
        {

        }


        /// <summary>
        /// Add check for view
        /// </summary>
        /// <param name="view"></param>
        public override void SetContentView(View view)
        {
            View vulgraad = FindViewById<View>(Resource.Layout.Vulgraad);
            
            if(view == vulgraad)
            {
                Button buttonOnder30 = FindViewById<Button>(Resource.Id.ButtonOnder30);
                Button buttonOnder50 = FindViewById<Button>(Resource.Id.ButtonOnder50);
                Button buttonOnder80 = FindViewById<Button>(Resource.Id.ButtonOnder80);
                Button buttonBoven80 = FindViewById<Button>(Resource.Id.ButtonBoven80);

                buttonOnder30.Click += Button_Click_Onder30;
                buttonOnder50.Click += Button_Click_Onder50;
                buttonOnder80.Click += Button_Click_Onder80;
                buttonBoven80.Click += Button_Click_Boven80;
            }

        }

        private void Button_Click(object sender, EventArgs e)
        {
            vulgraad.Id = Convert.ToInt32(editText.Text);

            count = 1;
            SetContentView(Resource.Layout.Vulgraad);
            
            //SetContentView(Resource.Layout.Vulgraad);
        }

        private void Button_Click_Onder30(object sender, EventArgs e)
        {
            vulgraad.VulgraadNiveau = "0-30%";

            SetContentView(Resource.Layout.activity_main);
        }

        private void Button_Click_Onder50(object sender, EventArgs e)
        {
            vulgraad.VulgraadNiveau = "30-50%";

            SetContentView(Resource.Layout.activity_main);
        }

        private void Button_Click_Onder80(object sender, EventArgs e)
        {
            vulgraad.VulgraadNiveau = "50-80%";

            SetContentView(Resource.Layout.activity_main);
        }

        private void Button_Click_Boven80(object sender, EventArgs e)
        {
            vulgraad.VulgraadNiveau = "> 80%";

            SetContentView(Resource.Layout.activity_main);
        }


        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
    }
}