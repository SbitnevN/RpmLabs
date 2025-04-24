using SportRent.Application.WorkSpaces.InventoryItem.Query;
using SportRent.Core.Abstractions;
using SportRent.Core.Tools;
using System.ComponentModel;

namespace SportRent.Application.WorkSpaces.InventoryItem
{
    public enum InventoryItemType
    {
        [Description("Силовые")]
        Strength,
        [Description("Кардио")]
        Cardio,
        [DisplayDataGrid("Баланс")]
        Balance
    }

    public class InventoryItemModel : ModelBase
    {
        [DisplayDataGrid(IsBlocked = true)]
        public IEnumerable<InventoryItemType> InventoryItemTypeValues { get; private set; } = Enum.GetValues(typeof(InventoryItemType))
            .Cast<InventoryItemType>()
            .ToList();

        [DisplayDataGrid(IsBlocked = true)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [DisplayDataGrid("Название")]
        public string Name { get; set; } = string.Empty;

        [DisplayDataGrid("Описание")]
        public string Description { get; set; } = string.Empty;

        [DisplayDataGrid("Размер")]
        public int Size { get; set; } = 0;

        [DisplayDataGrid("Цена")]
        public decimal Price { get; set; } = 0;

        [DisplayDataGrid("Тип")]
        public InventoryItemType ItemType { get; set; } = 0;

        public InventoryItemEntity ToEntity()
        {
            InventoryItemEntity entity = new InventoryItemEntity();
            entity.Id = Id;
            entity.Name = Name;
            entity.Description = Description;
            entity.Size = Size;
            return entity;
        }

        public override ValidateResult Validate()
        {
            ValidateResult result = new ValidateResult();

            if (string.IsNullOrEmpty(Name))
                result.Message = "Название не должно быть пустым";

            if (result.IsFail)
                Notify(result.Message);

            return result;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}