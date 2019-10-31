using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Test_VulgraadMeter
{
    class Vulgraad
    {
        public int Id { get; set; }
        public string VulgraadNiveau { get; set; }
        public DateTime Datum { get; set; }
        public string Tijdstip { get; set;  }

        public Vulgraad()
        {
            Datum = DateTime.Now.Date;
            Tijdstip = Convert.ToString(DateTime.Now.TimeOfDay);
        }

        public Vulgraad(int id, string vulgraadNiveau)
        {
            var tijd = String.Format("{0:HH:mm:ss.ffffff} ", DateTime.Now.TimeOfDay);

            this.Id = id;
            this.VulgraadNiveau = vulgraadNiveau;
            Datum = DateTime.Now.Date;
            Tijdstip = tijd;
                //Convert.ToString(DateTime.Now.TimeOfDay);
        }

        public async Task SaveCountAsync(int count)
        {
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "count.txt");
            //var backingFile = Path.Combine("/data", "count.txt");

            using (var writer = File.CreateText(backingFile))
            {
                try
                {
                    await writer.WriteLineAsync(count.ToString());
                }
                catch(Exception e)
                {

                }
            }
        }
    }
}