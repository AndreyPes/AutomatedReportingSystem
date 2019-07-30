using BusinessLogic.BL.Common.GeneralDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARSCommunicationService.BL.common.Infrastructure
{
   public interface ISlave
    {
        string UrlService { get; }
        Equipment GetEquipmentAsync();
        IEnumerable<Process> GetProcessesAsync();
    }
}
