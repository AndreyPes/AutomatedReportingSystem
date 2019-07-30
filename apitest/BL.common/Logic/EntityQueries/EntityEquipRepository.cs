using BusinessLogic.BL.Common.GeneralDataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using apitest.EquipmentEntity;
using OperationList = BusinessLogic.BL.Common.GeneralDataModel.OperationList;
using apitest.BL.common.Infrastructure;

namespace apitest.BL.common.Logic.EntityQueries
{
    public class EntityEquipRepository: IEntityEquipRepository
    {
        public async Task<Equipment> GetEquipmentAsync()
        {
            Equipment _equipment = null;
            using (var equipment = new EquipmentEF())
            {
                var db = (from c in equipment.State
                    select new Equipment
                    {
                        Id = c.ID,
                        EquipmentName = c.EquipmentName,
                        EquipmentState = c.EquipmentState,
                        VacuumPressure = c.VacuumPressure,
                        ProcessCount = c.ProcessCount
                    }).FirstOrDefaultAsync();
                try
                {
                    _equipment = await db;
                    return _equipment;
                }
                catch (Exception e)
                {
                    throw;
                }
            }

        }

        public async Task<IEnumerable<OperationList>> GetAllOperationsAsync()
        {
            IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.OperationList> _operationLists = null;
            using (var equipment = new EquipmentEF())
            {
                var db = from c in equipment.OperationList
                    select new BusinessLogic.BL.Common.GeneralDataModel.OperationList
                    {
                        Id = c.ID,
                        ProcessID = c.ProcessID,
                        Date = c.Date,
                        RecipeName = c.RecipeName,
                        Time = c.Time,
                        Parameter = c.Parameter
                    };
                try
                {
                    _operationLists = await db.ToArrayAsync();
                    return _operationLists;
                }
                catch (Exception e)
                {
                    throw;
                }
            }         
        }

        public async Task<IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.OperationList>> GetOperationsByProcIdAsync(int id)
        {

            IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.OperationList> _operationLists = null;
            using (var equipment = new EquipmentEF())
            {
                var db = from c in equipment.OperationList
                    //where c.Time != null
                    where c.ProcessID == id
                    select new BusinessLogic.BL.Common.GeneralDataModel.OperationList
                    {
                        Id = c.ID,
                        ProcessID = c.ProcessID,
                        Date = c.Date,
                        RecipeName = c.RecipeName,
                        Time = c.Time,
                        Parameter = c.Parameter
                    };
                try
                {
                    _operationLists = await db.ToArrayAsync();
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            return _operationLists;
        }

        public async Task<IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.Process>> GetProcessesAsync()
        {
            IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.Process> _processLists = null;
            using (var equipment = new EquipmentEF())
            {
                var db = from c in equipment.Process
                    //where c.IsCompleted == true
                    select new BusinessLogic.BL.Common.GeneralDataModel.Process()
                    {
                        Id = c.ID,
                        Date = c.Date,
                        Name = c.Name,
                        RecipeName = c.RecipeName,
                        CustomerName = c.CustomerName,
                        OperatorName = c.OperatorName,
                        PartName = c.PartName,
                        IsCompleted = c.IsCompleted,
                        IsFailed = c.IsFailed,
                        OperationList = (from op in equipment.OperationList
                            where op.ProcessID == c.ID
                            //where op.Time != null
                            select new BusinessLogic.BL.Common.GeneralDataModel.OperationList
                            {
                                Id = op.ID,
                                ProcessID = op.ProcessID,
                                Date = op.Date,
                                RecipeName = op.RecipeName,
                                Time = op.Time,
                                Parameter = op.Parameter
                            }).ToList()
                    };

                try
                {
                    _processLists = await db.ToArrayAsync();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return _processLists;

        }

        public async Task<IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.Process>> GetComplitedProcAsync()
        {

            IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.Process> _processLists = null;
            using (var equipment = new EquipmentEF())
            {
                var db = from c in equipment.Process
                    where c.IsCompleted == true
                    select new BusinessLogic.BL.Common.GeneralDataModel.Process
                    {
                        Id = c.ID,
                        Date = c.Date,
                        Name = c.Name,
                        RecipeName = c.RecipeName,
                        CustomerName = c.CustomerName,
                        OperatorName = c.OperatorName,
                        PartName = c.PartName,
                        IsCompleted = c.IsCompleted,
                        IsFailed = c.IsFailed
                    };
                try
                {
                    _processLists = await db.ToArrayAsync();
                    return _processLists;
                }
                catch (Exception e)
                {
                    throw;
                }
            }

        }

        public async Task<IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.Process>> GetFailedProcAsync()
        {

            IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.Process> _processLists = null;
            using (var equipment = new EquipmentEF())
            {
                var db = from c in equipment.Process
                    where c.IsFailed == false
                    select new BusinessLogic.BL.Common.GeneralDataModel.Process
                    {
                        Id = c.ID,
                        Date = c.Date,
                        Name = c.Name,
                        RecipeName = c.RecipeName,
                        CustomerName = c.CustomerName,
                        OperatorName = c.OperatorName,
                        PartName = c.PartName,
                        IsCompleted = c.IsCompleted,
                        IsFailed = c.IsFailed
                    };
                try
                {
                    _processLists = await db.ToArrayAsync();
                    return _processLists;
                }
                catch (Exception e)
                {
                    throw;
                }
            }

        }

        public async Task<LastProcess> GetLastProcPartAsync()
        {
            LastProcess _process = null;
            using (var equipment = new EquipmentEF())
            {
                var db = (from c in equipment.Process

                    select new LastProcess
                    {
                        Date = c.Date,
                        Name = c.Name,
                        IsCompleted = c.IsCompleted,
                        IsFailed = c.IsFailed
                    }).OrderByDescending(z => z.Date).FirstAsync();
                try
                {
                    _process = await db;
                    return _process;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        

        }

        public async Task<BusinessLogic.BL.Common.GeneralDataModel.Process> GetLastProcAsync()
        {
            BusinessLogic.BL.Common.GeneralDataModel.Process _process = null;
            using (var equipment = new EquipmentEF())
            {
                var db = (from c in equipment.Process

                    select new BusinessLogic.BL.Common.GeneralDataModel.Process
                    {
                        Id = c.ID,
                        Date = c.Date,
                        Name = c.Name,
                        RecipeName = c.RecipeName,
                        CustomerName = c.CustomerName,
                        OperatorName = c.OperatorName,
                        PartName = c.PartName,
                        IsCompleted = c.IsCompleted,
                        IsFailed = c.IsFailed
                    }).OrderByDescending(z => z.Date).FirstAsync();
                try
                {
                    _process = await db;
                    return _process;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        public async Task<IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.Spectrum>> GetSpectrumAsync()
        {

            IEnumerable<BusinessLogic.BL.Common.GeneralDataModel.Spectrum> _spectrumLists = null;
            using (var equipment = new EquipmentEF())
            {
                var db = from c in equipment.Spectrum
                    select new BusinessLogic.BL.Common.GeneralDataModel.Spectrum()
                    {
                        Id = c.ID,
                        ProcessID = c.ProcessID,
                        MeasValue1 = c.MeasValue1,
                        MeasValue2 = c.MeasValue2,
                        MeasValue3 = c.MeasValue3
                    };
                try
                {
                    _spectrumLists = await db.ToArrayAsync();
                    return _spectrumLists;
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

    }
}