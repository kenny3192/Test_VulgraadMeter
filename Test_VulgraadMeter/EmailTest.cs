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
using Xamarin.Essentials;

namespace Test_VulgraadMeter
{
    class EmailTest
    {
        public async Task SendEmail()
        {
            List<string> recipients = new List<string>();
            recipients.Add("1562185reijnders@zuyd.nl");

            CSVWriter v = new CSVWriter();
            var m = await v.ReadCountAsync();

            try
            {
                var message = new EmailMessage
                {
                    Subject = "Test app",
                    Body = Convert.ToString(m),
                    To = recipients,
                };

                var fn = "test.csv";
                var file = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "count.txt");
                //var file = Path.Combine(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData)), fn);
                File.WriteAllText(file, "Hello World");

                try
                {
                    message.Attachments.Add(new EmailAttachment(file));
                }
                catch (Exception e)
                {

                }

                await Email.ComposeAsync(message);


            }
            catch (FeatureNotSupportedException fbsEx)
            {
                // Email is not supported on this device
            }
            catch (Exception ex)
            {
                // Some other exception occurred
            }
        }
    }
}