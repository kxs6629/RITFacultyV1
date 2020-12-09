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
    // Service used to retrieve information from the staff node
    public class GetStaff
    {
        // Asynchronous call to the APi that returns data representing a list of the Staff model
        public async Task<List<Staff>> getAllStaff()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    // Wait for reponse, then read in data as a string
                    HttpResponseMessage response = await client.GetAsync("api/people/staff", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    // Process read in data as a list of Staff models
                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<Staff>>>(data);

                    // Create list of Staff models to be populated
                    List<Staff> staffList = new List<Staff>();

                    // Populate newly created staffList, then return it
                    foreach (KeyValuePair<string, List<Staff>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            staffList.Add(item);
                        }
                    }

                    return staffList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Staff> staffList = new List<Staff>();
                    return staffList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Staff> staffList = new List<Staff>();
                    return staffList;
                    //return "Exception"; ;
                }
            }
        }
    }
}
