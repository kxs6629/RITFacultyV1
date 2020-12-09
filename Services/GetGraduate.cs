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
    // Service used to retrieve information from the graduate node
    public class GetGraduate
    {
        // Asynchronous call to the APi that returns data representing a list of the Graduate model
        public async Task<List<Grad>> GetAllGrads()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    // Wait for response from server, then read in as string
                    HttpResponseMessage response = await client.GetAsync("api/degrees/graduate", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    // Process read in data as a list of Grad model objects
                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<Grad>>>(data);

                    //List of Graduate to be populated
                    List<Grad> gradList = new List<Grad>();
                    Grad grad= new Grad();

                    //Populate newly created gradList, then return it
                    foreach (KeyValuePair<string, List<Grad>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            gradList.Add(item);
                        }
                    }

                    return gradList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Grad> gradList = new List<Grad>();
                    return gradList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Grad> gradList= new List<Grad>();
                    return gradList;
                    //return "Exception"; 
                }
            }
        }
    }
}
