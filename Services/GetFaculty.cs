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
    // Service used to retrieve information from the faculty node
    public class GetFaculty
    {

        // Asynchronous call to the APi that returns data representing a list of the Faculty model
        public async Task<List<Faculty>> GetAllFaculty()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    // Wait for response, then read in data as a string
                    HttpResponseMessage response = await client.GetAsync("api/people/faculty", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    // Process the data as a list of Faculty models
                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<Faculty>>>(data);

                    // Create a list of faculty models from the newly created model, then return it
                    List<Faculty> facultyList = new List<Faculty>();
              
                    foreach (KeyValuePair<string, List<Faculty>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            facultyList.Add(item);
                        }
                    }

                    return facultyList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Faculty> facultyList = new List<Faculty>();
                    return facultyList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Faculty> facultyList = new List<Faculty>();
                    return facultyList;
                    //return "Exception"; ;
                }
            }
        }
    }
}
