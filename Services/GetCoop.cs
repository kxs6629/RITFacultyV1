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
    // Service used to retrieve information from the employment/coopTable node
    public class GetCoop
    {
        // Asynchronous call to the APi that returns data representing a list of the CoopInformation model
        public async Task<List<CoopInformation>> getAllCoops() 
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    // Wait for response from the server, then read data as a string
                    HttpResponseMessage response = await client.GetAsync("api/employment/coopTable", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    // Convert data read in as a Coop Model
                    var rtnResults = JsonConvert.DeserializeObject<Coop>(data);

                    //Retrieve the coopInformation model from this newly converted data, then return it
                    List<CoopInformation> coopList = rtnResults.coopTable.coopInformation;

                    return coopList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<CoopInformation> coopList = new List<CoopInformation>();
                    return coopList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<CoopInformation> coopList = new List<CoopInformation>();
                    return coopList;
                    //return "Exception"; 
                }
            }
        }
    }
}
