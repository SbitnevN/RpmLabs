using System.ComponentModel.DataAnnotations;

namespace MedRepairTrack.Core.DataAccess.Entities
{
    public class EquipmentEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string EquipmentType { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
    }
}
