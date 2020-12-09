using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RITFacultyV1.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace RITFacultyV1.Services
{
    // Service used to retrieve information from the about node
    public class GetAbout
    {
        // Asynchronous call to the APi that returns data representing the About model
        public async Task<About> GetAboutInfo()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    // Wait for response from the server, then read data as a string
                    HttpResponseMessage response = await client.GetAsync("api/about", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    // Convert the data into an About object
                    var rtnResults = JsonConvert.DeserializeObject<About>(data);
                    
                    // About object to return
                    About about = rtnResults;
            
                    return about;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    About about = new About();
                    return about;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    About about= new About();
                    return about;
                    //return "Exception"; 
                }
            }
        }

    }
}
