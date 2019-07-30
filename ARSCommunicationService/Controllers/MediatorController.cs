using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using ARSCommunicationService.BL.common.Logic.ConfigServiceList;
using ARSCommunicationService.BL.common.Logic.SlavesResponses;
using ARSCommunicationService.BL.common.Infrastructure;

namespace ARSCommunicationService.Controllers
{
    public class MediatorController : ApiController
    {        
        string[] _urlPathstrings = new ServiceList().GetPathsStrings();
        /// <summary>
        /// Получить информацию по оборудованию
        /// </summary>
        [System.Web.Http.Route("api/Mediator/GetEquipmentdata")]
        [System.Web.Http.ActionName("GetEquipmentdata")]
        public JsonResult<IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.EquipmentData>> GetEquipmentdata()
        {
             try
            {
                ISlavesResponse _slavesResponse=new SlavesResponse(_urlPathstrings);
                return Json(_slavesResponse.GetEquipmentdata());

            }
            catch (Exception e)
            {
                var _badResponse = new HttpResponseMessage(statusCode: HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(e.Message), Encoding.UTF8, "application/json")
                };
                throw new HttpResponseException(_badResponse);
            }        
        }

    }
}