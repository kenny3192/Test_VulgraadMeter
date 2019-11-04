using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.InputMethodServices;
using System;
using Android.Views;
using Plugin.Permissions;
using Android.Support.V4.Content;
using Android;
using Android.Content.PM;

namespace Test_VulgraadMeter
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText editText;
        Vulgraad vulgraad = new Vulgraad();
        Button buttonBin;
        int count = 0;
        CSVWriter csvWriter;
        EmailTest emailTest;
        Button buttonSend;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            csvWriter = new CSVWriter();
            emailTest = new EmailTest();

            

            //string message = string.Empty;

            //if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage) == (int)Permission.Granted &&
            //    ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) == (int)Permission.Granted)
            //{
            //    Android.App.AlertDialog.Builder alertDialog = new Android.App.AlertDialog.Builder(this);
            //    alertDialog.SetTitle("Titel");
            //    alertDialog.SetMessage("Permission granted");
            //    alertDialog.SetNeutralButton("OK", delegate {
            //        alertDialog.Dispose();
            //    });
            //    alertDialog.Show();
            //}
            //else
            //{
            //    Android.App.AlertDialog.Builder alertDialog = new Android.App.AlertDialog.Builder(this);
            //    alertDialog.SetTitle("Titel");
            //    alertDialog.SetMessage("Permission granted");
            //    alertDialog.SetNeutralButton("OK", delegate {
            //        alertDialog.Dispose();
            //    });
            //    alertDialog.Show();
            //}

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
                editText = FindViewById<EditText>(Resource.Id.editText1);
                buttonSend = FindViewById<Button>(Resource.Id.Send);


                buttonBin.Click += Button_Click;
                buttonSend.Click += ButtonSend_Click;
            }
        }




        public override void OnBackPressed()
        {

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
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
            if(editText.Text == null || editText.Text == "")
            {
                Android.App.AlertDialog.Builder alertDialog = new Android.App.AlertDialog.Builder(this);
                alertDialog.SetTitle("Waarschuwing");
                alertDialog.SetMessage("Vul het prullenbaknummer in!");
                alertDialog.SetNeutralButton("OK", delegate
                {
                    alertDialog.Dispose();
                });
                alertDialog.Show();
            }
            else
            {
                vulgraad.Id = 0;
                vulgraad.Id = Convert.ToInt32(editText.Text);

                count = 1;
                SetContentView(Resource.Layout.Vulgraad);
            }
            
            
            //SetContentView(Resource.Layout.Vulgraad);
        }

        private async void ButtonSend_Click(object sender, EventArgs e)
        {
            csvWriter.WriteObjectToCsv(vulgraad.GetListVulgraad());

            await emailTest.SendEmail(vulgraad);

        }

        private void Button_Click_Onder30(object sender, EventArgs e)
        {
            string tijd = String.Format("{0:t} ", DateTime.Now.TimeOfDay);
            //DateTime.Now.TimeOfDay.ToString("hh:mm:ss");

            vulgraad.VulgraadNiveau = "0-30%";
            vulgraad.Datum = DateTime.Now.ToString("dd-MM-yyyy");
            vulgraad.Tijdstip = tijd;

            vulgraad.VoegToeAanLijst(vulgraad);

            //csvWriter.WriteObjectToCsv(vulgraad.GetListVulgraad());


            //await csvWriter.SaveCountAsync(2);

            //await emailTest.SendEmail();

            SetContentView(Resource.Layout.activity_main);
        }

        private void Button_Click_Onder50(object sender, EventArgs e)
        {
            string tijd = String.Format("{0:t} ", DateTime.Now.TimeOfDay);

            vulgraad.VulgraadNiveau = "30-50%";
            vulgraad.Datum = DateTime.Now.ToString("dd-MM-yyyy");
            vulgraad.Tijdstip = tijd;

            //csvWriter.WriteObjectToCsv(vulgraad.GetListVulgraad());

            vulgraad.VoegToeAanLijst(vulgraad);

            SetContentView(Resource.Layout.activity_main);
        }

        private void Button_Click_Onder80(object sender, EventArgs e)
        {
            string tijd = String.Format("{0:t} ", DateTime.Now.TimeOfDay);

            vulgraad.VulgraadNiveau = "50-80%";
            vulgraad.Datum = DateTime.Now.ToString("dd-MM-yyyy");
            vulgraad.Tijdstip = tijd;

            //csvWriter.WriteObjectToCsv(vulgraad.GetListVulgraad());
            vulgraad.VoegToeAanLijst(vulgraad);

            SetContentView(Resource.Layout.activity_main);
        }

        private void Button_Click_Boven80(object sender, EventArgs e)
        {
            string tijd = String.Format("{0:t} ", DateTime.Now.TimeOfDay);

            vulgraad.VulgraadNiveau = "> 80%";
            vulgraad.Datum = DateTime.Now.ToString("dd-MM-yyyy");
            vulgraad.Tijdstip = tijd;

            //csvWriter.WriteObjectToCsv(vulgraad.GetListVulgraad());
            vulgraad.VoegToeAanLijst(vulgraad);

            SetContentView(Resource.Layout.activity_main);
        }


        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
    }
}