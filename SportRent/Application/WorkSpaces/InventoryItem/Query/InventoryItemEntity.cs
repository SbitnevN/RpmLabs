using SportRent.Application.WorkSpaces.User;
using SportRent.Core.Tools;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportRent.Application.WorkSpaces.InventoryItem.Query
{
    public class InventoryItemEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Size { get; set; } = 0;

        public decimal Price { get; set; } = 0;

        public InventoryItemType ItemType { get; set; } = 0;

        public InventoryItemModel ToModel()
        {
            InventoryItemModel inventoryItemModel = new InventoryItemModel();
            inventoryItemModel.Id = Id;
            inventoryItemModel.Name = Name;
            inventoryItemModel.Description = Description;
            inventoryItemModel.Size = Size;
            inventoryItemModel.ItemType = ItemType;
            inventoryItemModel.Price = Price;
            return inventoryItemModel;
        }
    }
}