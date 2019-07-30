using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using BusinessLogic.BL.Common.GeneralDataModel;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;
using ARS_WebApp.BL.common.Infrastructure;

namespace ARS_WebApp.BL.common.Logic
{
    public class Mediator: IMediator
    {
        public IEnumerable<EquipmentData> GetEquipmentData()
        {
            IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.EquipmentData> _equipment = null;
            using (var client = new System.Net.Http.HttpClient())
            {

                client.BaseAddress = new Uri("http://user-pc/CommunicationService/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                JavaScriptSerializer serializer1 = new JavaScriptSerializer();
                var response = client.GetAsync("api/Mediator/GetEquipmentdata").GetAwaiter().GetResult();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (HttpContent content = response.Content)
                    {
                        string res = "";
                        res = content.ReadAsStringAsync().GetAwaiter().GetResult();
                        _equipment = (IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.EquipmentData>)serializer1.Deserialize(res, typeof(IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.EquipmentData>));

                    }
                }
            }

            foreach (var s in _equipment)
            {
                s.Process = s.Process.OrderByDescending(x => x.Date).ToList();
                foreach (var n in s.Process)
                {
                    n.OperationList = n.OperationList.OrderByDescending(x => x.Date).ToList();
                }
            }

            return _equipment;
        }

    }
}