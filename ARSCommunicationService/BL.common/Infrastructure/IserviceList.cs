using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARSCommunicationService.BL.common.Infrastructure
{
    interface IServiceList
    {
        string[] GetPathsStrings();
        bool IfExist();
        bool HasData();
    }
}
