using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using apitest.BL.common.Logic.EntityQueries;
using BusinessLogic.BL.Common.GeneralDataModel;
using apitest.BL.common.Infrastructure;

namespace apitest.Controllers
{    
    public class EquipmentController : ApiController
    {
        IEntityEquipRepository EquipRepository=new EntityEquipRepository();
        private JavaScriptSerializer _serializer = new JavaScriptSerializer();
        [System.Web.Http.Route("api/Equipment/Get")]
        [System.Web.Http.ActionName("Get")]
        //public async Task<IHttpActionResult> Get()
        public  async Task<JsonResult<Equipment>> Get()
        {         
            try
            {
                return Json(await EquipRepository.GetEquipmentAsync());
                //JavaScriptSerializer serializer1 = new JavaScriptSerializer();
                //return Ok(serializer1.Serialize( await EquipRepository.GetEquipmentAsync()));
            }
            catch (Exception e)
            {
                var _badResponse = new HttpResponseMessage(statusCode: HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(e.Message), Encoding.UTF8, "application/json")
                };
              throw  new HttpResponseException(_badResponse);
            } 
        }
        /// <summary>
        /// Все операции
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.Route("api/Equipment/GetOperations")]
        [System.Web.Http.ActionName("GetOperations")]
        public async Task<JsonResult<IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.OperationList>>> GetOperations()
        {
            try
            {

                return Json(await EquipRepository.GetAllOperationsAsync());
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

        /// <summary>
        /// проведённые операции по id процесса
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.Route("api/Equipment/GetOperationsByProcId/{id}")]
        [System.Web.Http.ActionName("GetOperationsByProcId")]
        public async Task<JsonResult<IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.OperationList>>> GetOperationsByProcId(int id)
        {

            try
            {

                return Json(await EquipRepository.GetOperationsByProcIdAsync(id));
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

        /// <summary>
        /// Спиоск проведенных процессов 
        /// Список проведенных операций 
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.Route("api/Equipment/GetProcesses")]
        [System.Web.Http.ActionName("GetProcesses")]
        public async Task<JsonResult<IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.Process>>> GetProcesses()
        {
            try
            {

                return Json(await EquipRepository.GetProcessesAsync());
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

        /// <summary>
        /// Завершенные процессы
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.Route("api/Equipment/GetComplitedProc")]
        [System.Web.Http.ActionName("GetComplitedProc")]
        public async Task<JsonResult<IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.Process>>> GetComplitedProc()
        {
            try
            {

                return Json(await EquipRepository.GetComplitedProcAsync());
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

        /// <summary>
        /// Завершенные с ошибкой процессы
        /// </summary>
        /// <returns></returns>
        [System.Web.Http.Route("api/Equipment/GetFailedProc")]
        [System.Web.Http.ActionName("GetFailedProc")]
        public async Task<JsonResult<IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.Process>>> GetFailedProcAsync()
        {
            try
            {

                return Json(await EquipRepository.GetComplitedProcAsync());
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


        [System.Web.Http.Route("api/Equipment/GetLastProcPart")]
        [System.Web.Http.ActionName("GetLastProcPart")]
        public async Task<JsonResult<LastProcess>> GetLastProcPart()
        {
            try
            {

                return Json(await EquipRepository.GetLastProcPartAsync());
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

        /// <summary>
        /// Получить последний процесс
        /// </summary>
        /// <returns>Process</returns>
        [System.Web.Http.Route("api/Equipment/GetLastProc")]
        [System.Web.Http.ActionName("GetLastProc")]
        public async Task<JsonResult<BusinessLogic.BL.Common.GeneralDataModel.Process>> GetLastProc()
        {
            try
            {

                return Json(await EquipRepository.GetLastProcAsync());
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

        /// <summary>
        /// Получить данные Spectrum
        /// </summary>
        /// <returns>Spectrum</returns>
        [System.Web.Http.Route("api/Equipment/GetSpectrum")]
        [System.Web.Http.ActionName("GetSpectrum")]
        public async Task<JsonResult<IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.Spectrum>>> GetSpectrum()
        {
            try
            {

                return Json(await EquipRepository.GetSpectrumAsync());
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