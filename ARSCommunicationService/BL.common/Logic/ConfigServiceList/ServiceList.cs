using System.IO;
using System.Web;
using ARSCommunicationService.BL.common.Infrastructure;

namespace ARSCommunicationService.BL.common.Logic.ConfigServiceList
{
    public class ServiceList: IServiceList
    {
        string _fileConfigPath;

        public ServiceList()
        {
            _fileConfigPath = HttpContext.Current.Server.MapPath("~/App_Data/ServiceList.txt");
        }

        public string[] GetPathsStrings()
        {
            if (IfExist() && HasData())
                return File.ReadAllLines(_fileConfigPath);
            else
                return null;
        }

        public bool IfExist()
        {
            return File.Exists(_fileConfigPath);
        }

        public bool HasData()
        {
            return (new FileInfo(_fileConfigPath).Length != 0);
        }


    }
}