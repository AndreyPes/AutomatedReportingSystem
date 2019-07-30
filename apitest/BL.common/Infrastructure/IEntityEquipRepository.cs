using BusinessLogic.BL.Common.GeneralDataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apitest.BL.common.Infrastructure
{
  public  interface IEntityEquipRepository
  {
      Task<Equipment> GetEquipmentAsync();
      Task<IEnumerable<OperationList>> GetAllOperationsAsync();
      Task<IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.OperationList>> GetOperationsByProcIdAsync(int id);
      Task<IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.Process>> GetProcessesAsync();
      Task<IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.Process>> GetComplitedProcAsync();
      Task<IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.Process>> GetFailedProcAsync();
      Task<LastProcess> GetLastProcPartAsync();
      Task<BusinessLogic.BL.Common.GeneralDataModel.Process> GetLastProcAsync();
      Task<IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.Spectrum>> GetSpectrumAsync();

  }
}
