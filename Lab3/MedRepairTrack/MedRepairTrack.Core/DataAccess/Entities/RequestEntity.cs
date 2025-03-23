using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedRepairTrack.Core.DataAccess.Entities
{
    public class RequestEntity
    {
        [Key]
        public Guid Number { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string Description { get; set; } = string.Empty;

        public string RequestStatus { get; set; } = string.Empty;

        public Guid? UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserEntity? User { get; set; }

        public Guid? EquipmentId { get; set; }
        
        [ForeignKey(nameof(EquipmentId))]
        public EquipmentEntity? Equipment { get; set; }
    }
}
