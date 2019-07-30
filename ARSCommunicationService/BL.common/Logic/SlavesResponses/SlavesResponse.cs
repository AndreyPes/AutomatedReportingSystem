using System.Collections.Generic;
using ARSCommunicationService.BL.common.Infrastructure;
using ARS_CommunityAPI.BL.common.Logic.SlaveQueries;
using BusinessLogic.BL.Common.GeneralDataModel;


namespace ARSCommunicationService.BL.common.Logic.SlavesResponses
{
    public class SlavesResponse: ISlavesResponse
    {    
        public SlavesResponse(string[] urlPathStrings)
        {
            _urlPathStrings = urlPathStrings;
           
        }

        private string[] _urlPathStrings;
        public ISlave Slave { get; private set; }

        public IEnumerable<EquipmentData> GetEquipmentdata()
        {

            List<EquipmentData> EquipmentDataList=new List<EquipmentData>();
            foreach (var s in _urlPathStrings)
            {
                Slave =new Slave(s);
                var _equipment = Slave.GetEquipmentAsync();
                var _processes = Slave.GetProcessesAsync();
                if(_equipment!=null)
                EquipmentDataList.Add(new EquipmentData(_processes, _equipment));
            }

            return EquipmentDataList;


        }
    }
}