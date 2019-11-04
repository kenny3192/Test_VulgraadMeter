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
            Tijdstip = DateTime.Now.ToString("HH:mm:ss");
            vulgraadLijst = new List<Vulgraad>();
        }

        public Vulgraad(int id, string vulgraadNiveau)
        {
            var tijd = DateTime.Now.ToString("HH:mm:ss");

            this.Id = id;
            this.VulgraadNiveau = vulgraadNiveau;
            Datum = DateTime.Now.ToString("dd-MM-yyyy");
            Tijdstip = tijd;
                //Convert.ToString(DateTime.Now.TimeOfDay);
        }

        public void VoegToeAanLijst(Vulgraad v)
        {
            Vulgraad vulgraad = new Vulgraad(v.Id, v.VulgraadNiveau);
            vulgraad.Datum = v.Datum;
            vulgraad.Tijdstip = v.Tijdstip;
            
            this.vulgraadLijst.Add(vulgraad);
        }

        public List<Vulgraad> GetListVulgraad()
        {
            return this.vulgraadLijst;
        }

        public string GetDataFromList()
        {
            string v = "ID, Vulgraadniveau, Datum, Tijdstip";
            v += System.Environment.NewLine;

            foreach(Vulgraad vulgraad in this.vulgraadLijst)
            {
                v += vulgraad.Id.ToString() + ", " + vulgraad.VulgraadNiveau + ", " + vulgraad.Datum.ToString() + ", " + vulgraad.Tijdstip.ToString();
                v += System.Environment.NewLine;
            }
            return v;
        }

        
    }
}