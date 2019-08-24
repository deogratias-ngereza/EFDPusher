using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using EFDPusher.App.Models;

namespace EFDPusher.App
{
    public class Pusher
    {
        private MainController mainController;
        public Pusher() {
            mainController = new MainController();
        }

        public void push(string fn,string fp,string fd) {
            //try to push the post request
            // Create an HttpClient instance
            HttpClient httpClient = new HttpClient();

            PostData pD = new PostData{
                file_name = fn,
                file_data = fd
            };
            var stringContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("file_name", fn),
                new KeyValuePair<string, string>("file_data", fd),
            });
            try
            {
                var response = httpClient.PostAsync(mainController.getConfigurations().destination_ip, stringContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ EXCEPTION ] " + ex.Message);
            }
            
        }


        public void xpush(string fn, string fp, string fd)
        {
            //try to push the post request
            // Create an HttpClient instance
            HttpClient client = new HttpClient();


            // Send a request asynchronously continue when complete
            client.GetAsync("http://localhost:6677/efd").ContinueWith(
                (requestTask) =>
                {
                    // Get HTTP response from completed task.
                    HttpResponseMessage response = requestTask.Result;

                    // Check that response was successful or throw exception
                    response.EnsureSuccessStatusCode();

                    // Read response asynchronously as JsonValue and write out top facts for each country
                    /*response.Content.ReadAsAsync<JsonArray>().ContinueWith(
                        (readTask) =>
                        {
                            Console.WriteLine("First 50 countries listed by The World Bank...");
                            foreach (var country in readTask.Result[1])
                            {
                                Console.WriteLine("   {0}, Country Code: {1}, Capital: {2}, Latitude: {3}, Longitude: {4}",
                                    country.Value["name"],
                                    country.Value["iso2Code"],
                                    country.Value["capitalCity"],
                                    country.Value["latitude"],
                                    country.Value["longitude"]);
                            }
                        });*/
                });
        }

    }
}
