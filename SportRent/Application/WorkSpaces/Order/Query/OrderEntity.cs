using SportRent.Application.WorkSpaces.InventoryItem.Query;
using SportRent.Application.WorkSpaces.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportRent.Application.WorkSpaces.Order
{
    public class OrderEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid? UserId { get; set; }

        public Guid? InventoryItemId { get; set; }

        public DateTime? EndDate {  get; set; }

        [ForeignKey(nameof(UserId))]
        public UserEntity? User { get; set; }

        [ForeignKey(nameof(InventoryItemId))]
        public InventoryItemEntity? InventoryItem { get; set; }

        public OrderModel ToModel()
        {
            OrderModel model = new OrderModel();
            model.Id = Id;
            model.UserId = UserId;
            model.InventoryItemId = InventoryItemId;
            model.EndDate = EndDate;
            model.InventoryItem = InventoryItem?.ToModel();
            model.User = User?.ToModel();
            return model;
        }
    }
}