using ARS_CommunityAPI.BL.common.Logic.SlaveQueries;
using BusinessLogic.BL.Common.GeneralDataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARSCommunicationService.BL.common.Infrastructure
{
   public interface ISlavesResponse
    {
        ISlave Slave { get; }
        IEnumerable<EquipmentData> GetEquipmentdata();
    }
}
