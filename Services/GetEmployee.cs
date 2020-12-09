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
    // Service used to retrieve information from the employment/employmentTable node
    public class GetEmployee
    {
        // Asynchronous call to the APi that returns data representing a list of the ProfessionalEmploymentInformation model
        public async Task<List<ProfessionalEmploymentInformation>> getAllEmps()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    // Wait for response from server, then process data as a string
                    HttpResponseMessage response = await client.GetAsync("api/employment/employmentTable", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    // Convert the processed data as an Employee data model
                    var rtnResults = JsonConvert.DeserializeObject<Employee>(data);

                    //Retrieve the ProfessionalEmploymentInformation model from the newly created Employee data, then return it
                    List<ProfessionalEmploymentInformation> empList = rtnResults.employmentTable.professionalEmploymentInformation;

                    return empList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<ProfessionalEmploymentInformation> empList= new List<ProfessionalEmploymentInformation>();
                    return empList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<ProfessionalEmploymentInformation> empList = new List<ProfessionalEmploymentInformation>();
                    return empList;
                    //return "Exception"; 
                }
            }
        }
    }
}
