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
    public class GetEmployee
    {
        public async Task<List<ProfessionalEmploymentInformation>> getAllEmps()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/employment/employmentTable", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    var rtnResults = JsonConvert.DeserializeObject<Employee>(data);

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
