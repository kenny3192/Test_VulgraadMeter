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



        public void WriteObjectToCsv(List<Vulgraad> vulgraadLijst)
        {
            //string fileName = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "test.csv");
            string fileName = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "test.csv");


            csvWriter.Configuration.Delimiter = ";";

            csvWriter.WriteField("Id");
            csvWriter.WriteField("Vulgraadniveau");
            csvWriter.WriteField("Datum");
            csvWriter.WriteField("Tijdstip");
            csvWriter.NextRecord();

            foreach(Vulgraad v in vulgraadLijst)
            {
                csvWriter.WriteField(v.Id);
                csvWriter.WriteField(v.VulgraadNiveau);
                csvWriter.WriteField(v.Datum);
                csvWriter.WriteField(v.Tijdstip);
                csvWriter.NextRecord();
            }

            

            writer.Flush();
            var result = Encoding.UTF8.GetString(mem.ToArray());

            File.WriteAllText(fileName, csvWriter.ToString());

        }

        //public async Task WriteObjectToCsv2(List<Vulgraad> vulgraadLijst)
        //{
        //    var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "test.csv");

        //    using (var writer = File.CreateText(backingFile))
        //    {
        //        try
        //        {
        //            await writer.WriteLineAsync(count.ToString());
        //        }
        //        catch (Exception e)
        //        {

        //        }
        //    }
        //}
    


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
                catch (Exception e)
                {

                }
            }
        }

        public async Task<int> ReadCountAsync()
        {
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "count.txt");

            if (backingFile == null || !File.Exists(backingFile))
            {
                return 0;
            }

            var count = 0;
            using (var reader = new StreamReader(backingFile, true))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (int.TryParse(line, out var newcount))
                    {
                        count = newcount;
                    }
                }
            }

            return count;
        }

        public async Task<string> ReadCsvAsync()
        {
            string v = "";



            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "test.csv");

            if (backingFile == null || !File.Exists(backingFile))
            {
                return v;
            }

            using (var reader = new StreamReader(backingFile, true))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (line != null && line != "")
                    {
                        v += line;
                        v += System.Environment.NewLine;
                    }
                }
            }




            return v;
        }

        public string GetData(Vulgraad v)
        {
            string vulgraad = v.GetDataFromList();
            return vulgraad;
        }
    }
}