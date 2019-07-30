using BusinessLogic.BL.Common.GeneralDataModel;
using System.Collections.Generic;

namespace ARS_WebApp.BL.common.Infrastructure
{
    public interface IMediator
    {
        IEnumerable<EquipmentData> GetEquipmentData();
    }
}
