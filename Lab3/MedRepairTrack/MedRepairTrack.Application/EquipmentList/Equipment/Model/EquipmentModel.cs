using MedRepairTrack.Core.Abstractions;
using MedRepairTrack.Core.DataAccess.Entities;
using MedRepairTrack.Core.Extensions;

namespace MedRepairTrack.Application.EquipmentList.Equipment.Model
{
    public enum EquipmentType
    {
        UltraSound,
        XRay
    }

    public class EquipmentModel : ICloneable, IValidatable
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public EquipmentType EquipmentType { get; set; }

        public List<EquipmentType> EquipmentTypeValues { get; private set; } = Enum.GetValues(typeof(EquipmentType))
            .Cast<EquipmentType>()
            .ToList();

        public string Model { get; set; } = string.Empty;

        public static EquipmentEntity? ToEntity(EquipmentModel? model)
        {
            return (model == null) ? null : new EquipmentEntity()
            {
                Id = model.Id,
                Model = model.Model,
                EquipmentType = model.EquipmentType.ToString(),
            };
        }

        public static EquipmentModel? FromEntity(EquipmentEntity? entity)
        {
            return (entity == null) ? null : new EquipmentModel()
            {
                Id = entity.Id,
                Model = entity.Model,
                EquipmentType = entity.EquipmentType.ParseEnum<EquipmentType>(),
            };
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{EquipmentType} - {Model}";
        }

        public string Validate()
        {
            if (Model.IsNullOrEmpty())
            {
                return "Модель не должна быть пустой";
            }

            return string.Empty;
        }
    }
}
