using MedRepairTrack.Application.EquipmentList.Equipment.Model;
using MedRepairTrack.Core.DataAccess;
using MedRepairTrack.Core.DataAccess.Entities;
using MedRepairTrack.Core.Extensions;
using System.Data.Entity;

namespace MedRepairTrack.Application.EquipmentList.Equipment.Queries
{
    public class EquipmentQueries
    {
        private EquipmentQueries() { }

        public static readonly EquipmentQueries Instance = new EquipmentQueries();

        private DatabaseContext _dataBaseContext => DatabaseContext.Instance;

        public void Add(EquipmentModel equipment)
        {
            EquipmentEntity equipmentEntity = new EquipmentEntity()
            {
                Id = equipment.Id,
                Model = equipment.Model,
                EquipmentType = equipment.EquipmentType.ToString(),
            };

            _dataBaseContext.Equipments.Add(equipmentEntity);
            _dataBaseContext.SaveChanges();
        }

        public IList<EquipmentModel> GetAll()
        {
            IList<EquipmentModel> result = _dataBaseContext.Equipments.AsNoTracking().Select(e => new EquipmentModel()
            {
                Id = e.Id,
                Model = e.Model,
                EquipmentType = e.EquipmentType.ParseEnum<EquipmentType>()
            }).ToList();

            return result;
        }

        public void Edit(EquipmentModel equipmentModel)
        {
            EquipmentEntity? equipmentEntity = _dataBaseContext.Equipments.AsNoTracking().FirstOrDefault(e => e.Id == equipmentModel.Id);

            if (equipmentEntity == null)
            {
                Add(equipmentModel);
                return;
            }

            equipmentEntity.Model = equipmentModel.Model;
            equipmentEntity.EquipmentType = equipmentModel.EquipmentType.ToString();

            _dataBaseContext.SaveChanges();
        }
    }
}
