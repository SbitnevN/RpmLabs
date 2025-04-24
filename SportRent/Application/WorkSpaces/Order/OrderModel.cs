using SportRent.Application.WorkSpaces.InventoryItem;
using SportRent.Application.WorkSpaces.User;
using SportRent.Core.Abstractions;
using SportRent.Core.Tools;
using System.Xml.Linq;

namespace SportRent.Application.WorkSpaces.Order
{
    public class OrderModel : ModelBase
    {
        [DisplayDataGrid(IsBlocked = true)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [DisplayDataGrid("Владелец")]
        public string OwnerName => User?.Name ?? string.Empty;

        [DisplayDataGrid("Название")]
        public string InventoryName => InventoryItem?.Name ?? string.Empty;

        [DisplayDataGrid(IsBlocked = true)]
        public Guid? UserId { get; set; }

        [DisplayDataGrid(IsBlocked = true)]
        public UserModel? User { get; set; }

        [DisplayDataGrid(IsBlocked = true)]
        public Guid? InventoryItemId { get; set; }

        [DisplayDataGrid(IsBlocked = true)]
        public InventoryItemModel? InventoryItem { get; set; }

        [DisplayDataGrid("Дата окончания")]
        public DateTime? EndDate { get; set; }

        public OrderEntity ToEntity()
        {
            OrderEntity entity = new OrderEntity();
            entity.Id = Id;
            entity.UserId = UserId;
            entity.InventoryItemId = InventoryItemId;
            entity.EndDate = EndDate;
            return entity;
        }

        public override ValidateResult Validate()
        {
            ValidateResult result = new ValidateResult();

            if (UserId is null)
                result.Message = "Пользователь ис нулл";

            if (InventoryItemId is null)
                result.Message = "Нужно выбрать инвентарь";

            if (EndDate is null)
                result.Message = "Укажите дату окончания";

            if (EndDate < DateTime.Now)
                result.Message = "Нужно дату позже сейчас";

            if (result.IsFail)
                Notify(result.Message);

            return result;
        }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}