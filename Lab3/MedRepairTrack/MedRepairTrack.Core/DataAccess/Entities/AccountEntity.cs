using System.ComponentModel.DataAnnotations;

namespace MedRepairTrack.Core.DataAccess.Entities
{
    public class AccountEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
