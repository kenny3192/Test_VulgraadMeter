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
        public string Datum { get; set; }
        public string Tijdstip { get; set;  }

        private List<Vulgraad> vulgraadLijst;

        public Vulgraad()
        {
            Datum = DateTime.Now.ToString("dd-MM-yyyy");
            Tijdstip = Convert.ToString(DateTime.Now.TimeOfDay);
            vulgraadLijst = new List<Vulgraad>();
        }

        public Vulgraad(int id, string vulgraadNiveau)
        {
            var tijd = String.Format("{0:HH:mm:ss.ffffff} ", DateTime.Now.TimeOfDay);

            this.Id = id;
            this.VulgraadNiveau = vulgraadNiveau;
            Datum = DateTime.Now.ToString("dd-MM-yyyy");
            Tijdstip = tijd;
                //Convert.ToString(DateTime.Now.TimeOfDay);
        }

        public void VoegToeAanLijst(Vulgraad v)
        {
            this.vulgraadLijst.Add(v);
        }

        public List<Vulgraad> GetListVulgraad()
        {
            return this.vulgraadLijst;
        }

        
    }
}