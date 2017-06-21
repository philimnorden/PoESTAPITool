using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace PoESTAPITool
{
    class StashTab {

        static String url = "http://www.pathofexile.com/api/public-stash-tabs";
        static String urlsuffix = "?id=";
        static String id = "";
        static int counter = 1;

        public StashTab() {
            Console.WriteLine("Starting...");
            using (WebClient wc = new WebClient()) {

                //Download
                Console.WriteLine("Downloading first json");
                DateTime startTime = DateTime.Now;

                var json = wc.DownloadString(url);

                TimeSpan endTime = DateTime.Now.Subtract(startTime);
                Console.WriteLine("Done in " + endTime.TotalSeconds + " seconds");


                //Deserialize
                startTime = DateTime.Now;
                Console.WriteLine("Extracting next_change_id...");

                var def = new { next_change_id = "" };
                var output = JsonConvert.DeserializeAnonymousType(json, def);

                endTime = DateTime.Now.Subtract(startTime);
                Console.WriteLine("Found: " + output + " in " + endTime.TotalSeconds + " seconds");

                id = output.next_change_id;
                Console.WriteLine("Finished kickoff procedure");


            }
        }

        public void DownloadJsonIntoDir(){

            using (WebClient wc = new WebClient())
            {

                Console.WriteLine("Iteration " + counter);

                //Download
                var downloadstring = url + urlsuffix + id;
                Console.WriteLine("Downloading json from " + downloadstring);
                DateTime startTime = DateTime.Now;

                var json = wc.DownloadString(downloadstring);

                TimeSpan endTime = DateTime.Now.Subtract(startTime);
                Console.WriteLine("Done in " + endTime.TotalSeconds + " seconds");


                //Deserialize
                startTime = DateTime.Now;
                Console.WriteLine("Extracting next_change_id...");

                var def = new { next_change_id = "" };
                var output = JsonConvert.DeserializeAnonymousType(json, def);

                endTime = DateTime.Now.Subtract(startTime);
                Console.WriteLine("Found: " + output + " in " + endTime.TotalSeconds + " seconds");

                // set new id
                id = output.next_change_id;

                //Save
                var filename = counter + "_" + id + ".json";
                //var dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Data\" + filename;

                var dir = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Data\\" + filename);
                File.WriteAllText(dir, json);

                    
                
                counter++;

            }
        }

    }

}
