using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CsvHelper;

namespace Test_VulgraadMeter
{
    class CSVWriter
    {
        private MemoryStream mem;
        private StreamWriter writer;
        private CsvWriter csvWriter;
        
        public CSVWriter()
        {
            mem = new MemoryStream();
            writer = new StreamWriter(mem);
            csvWriter = new CsvWriter(writer);

        }



        public void WriteObjectToCsv(Vulgraad vulgraad)
        {
            string fileName = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "temp.txt");

            csvWriter.Configuration.Delimiter = ";";

            csvWriter.WriteField("Id");
            csvWriter.WriteField("Vulgraadniveau");
            csvWriter.WriteField("Datum");
            csvWriter.WriteField("Tijdstip");
            csvWriter.NextRecord();


            csvWriter.WriteField(vulgraad.Id);
            csvWriter.WriteField(vulgraad.VulgraadNiveau);
            csvWriter.WriteField(vulgraad.Datum);
            csvWriter.WriteField(vulgraad.Tijdstip);
            csvWriter.NextRecord();

            writer.Flush();
            var result = Encoding.UTF8.GetString(mem.ToArray());
        }
    }
}