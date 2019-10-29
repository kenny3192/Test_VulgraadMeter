using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public DateTime Datum { get; }
        public DateTime Tijdstip { get; }

        public Vulgraad()
        {
            Datum = DateTime.Now;
            Tijdstip = DateTime.Now;
        }

        public Vulgraad(int id, string vulgraadNiveau)
        {
            this.Id = id;
            this.VulgraadNiveau = vulgraadNiveau;
            Datum = DateTime.Now;
            Tijdstip = DateTime.Now;
        }
    }
}