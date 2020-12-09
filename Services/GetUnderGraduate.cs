﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RITFacultyV1.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace RITFacultyV1.Services
{
    public class GetUnderGraduate
    {
        public async Task<List<UnderGradMajors>> GetAllUnderGrads()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/degrees/undergraduate", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<UnderGradMajors>>>(data);

                    List<UnderGradMajors> underGradList = new List<UnderGradMajors>();
                    //UnderGradMajors underGrad = new UnderGradMajors();

                    foreach (KeyValuePair<string, List<UnderGradMajors>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            underGradList.Add(item);
                        }
                    }

                    return underGradList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<UnderGradMajors> underGradList = new List<UnderGradMajors>();
                    return underGradList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<UnderGradMajors> underGradList = new List<UnderGradMajors>();
                    return underGradList;
                    //return "Exception"; 
                }
            }
        }
    }
}
