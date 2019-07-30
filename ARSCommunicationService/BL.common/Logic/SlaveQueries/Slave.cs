using BusinessLogic.BL.Common.GeneralDataModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;
using ARSCommunicationService.BL.common.Infrastructure;

namespace ARS_CommunityAPI.BL.common.Logic.SlaveQueries
{
    public class Slave: ISlave
    {
        public Slave(string urlPath)
        {
            UrlService = urlPath;
        }

        public string UrlService { get;private set; }

        public Equipment GetEquipmentAsync()
        {
            //Получить все оборудование
            Equipment _equipment = null;
            ///Отображение списка подключенного оборудования               
            using (var client = new System.Net.Http.HttpClient())
            {
                try
                {
                  
                    client.BaseAddress = new Uri(UrlService);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    JavaScriptSerializer serializer1 = new JavaScriptSerializer();
                    var response = client.GetAsync("Api/Equipment/Get").GetAwaiter().GetResult();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (HttpContent content = response.Content)
                        {
                            
                            string res = "";
                            res = content.ReadAsStringAsync().GetAwaiter().GetResult();
                            _equipment = (Equipment) serializer1.Deserialize(res, typeof(Equipment));
                    
                        }
                    }
                    return _equipment;
                }
                catch (Exception e)
                {
                    throw;
                }

            }
        }


        public IEnumerable<Process> GetProcessesAsync()
        {
            //Получить все оборудование
            IEnumerable<Process> _equipment = null;
            ///Отображение списка подключенного оборудования               
            using (var client = new System.Net.Http.HttpClient())
            {
                try
                {

                    client.BaseAddress = new Uri(UrlService);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    JavaScriptSerializer serializer1 = new JavaScriptSerializer();
                    var response = client.GetAsync("Api/Equipment/GetProcesses").GetAwaiter().GetResult();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (HttpContent content = response.Content)
                        {
                            string res = "";
                            res = content.ReadAsStringAsync().GetAwaiter().GetResult();
                            _equipment = (IEnumerable<Process>)serializer1.Deserialize(res, typeof(IEnumerable<Process>));

                        }
                    }
                    return _equipment;
                }
                catch (Exception e)
                {
                    throw;
                }

            }
        }
    }
}
