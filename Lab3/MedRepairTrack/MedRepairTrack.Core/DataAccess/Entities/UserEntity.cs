using System.ComponentModel.DataAnnotations;

namespace MedRepairTrack.Core.DataAccess.Entities
{
    public class UserEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
