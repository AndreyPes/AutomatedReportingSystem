using System.Web.Mvc;
using System.Web.Http;



namespace ARSCommunicationService.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        public HomeController(HttpConfiguration config)
        {
            Configuration = config;
        }

        public HttpConfiguration Configuration { get; private set; }


        public ActionResult Index()
        {



            ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();


            ////получить все оборудование
            //IEnumerable<Equipment> _equipment;
            //IEnumerable<Process> _processLists;
            //IEnumerable<OperationList> _operationList;
            ///// Отображение списка подключенного оборудования
            //using (var client = new System.Net.Http.HttpClient())
            //{
               
            //    client.BaseAddress = new Uri("http://localhost:55061");
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
            //    JavaScriptSerializer serializer1 = new JavaScriptSerializer();
            //    var response =  client.GetAsync("Api/Equipment/Get").GetAwaiter().GetResult();
            //    string res = "";
            //    using (HttpContent content = response.Content)
            //    {
            //        res= content.ReadAsStringAsync().GetAwaiter().GetResult();
            //        _equipment = (IEnumerable<Equipment>)serializer1.Deserialize(res, typeof(IEnumerable<Equipment>));
            //    }
            //}



            /////	Отображение списка проведенных процессов на выбранном оборудовании
            //using (var client = new System.Net.Http.HttpClient())
            //{

            //    client.BaseAddress = new Uri("http://localhost:55061");
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    JavaScriptSerializer serializer1 = new JavaScriptSerializer();
            //    var response = client.GetAsync("Api/Equipment/GetComplitedProc").GetAwaiter().GetResult();
            //    string res = "";
            //    using (HttpContent content = response.Content)
            //    {
            //        res = content.ReadAsStringAsync().GetAwaiter().GetResult();
            //        _processLists = (IEnumerable<Process>)serializer1.Deserialize(res, typeof(IEnumerable<Process>));
            //    }
            //}




            /////	Отображение списка проведенных операций выбранного процесса
            //using (var client = new System.Net.Http.HttpClient())
            //{

            //    client.BaseAddress = new Uri("http://localhost:55061");
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    JavaScriptSerializer serializer1 = new JavaScriptSerializer();
            //    var response = client.GetAsync("Api/Equipment/GetOperationsByProcId/1").GetAwaiter().GetResult();
            //    string res = "";
            //    using (HttpContent content = response.Content)
            //    {
            //        res = content.ReadAsStringAsync().GetAwaiter().GetResult();
            //        _operationList = (IEnumerable<OperationList>)serializer1.Deserialize(res, typeof(IEnumerable<OperationList>));
            //    }
            //}



            return View(Configuration.Services.GetApiExplorer().ApiDescriptions);

            //ViewBag.Title = "Home Page";

            //return View();
        }
    }

}
