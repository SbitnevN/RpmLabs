using Microsoft.EntityFrameworkCore;
using SportRent.Application.WorkSpaces.Order;
using SportRent.Core.Abstractions;
using SportRent.Database;

namespace SportRent.Application.WorkSpaces.InventoryItem.Query
{
    public static class InventoryItemQuery
    {
        private static DatabaseContext DatabaseContext = DatabaseContext.Instance;

        public static IEnumerable<InventoryItemModel> GetAll()
        {
            return DatabaseContext.InventoryItems.AsNoTracking().Select(i => i.ToModel()).ToList();
        }

        public static IEnumerable<InventoryItemModel> GetFree()
        {
            IList<Guid?> orders = DatabaseContext.Orders.AsNoTracking().Select(o => o.InventoryItemId).ToList();
            return DatabaseContext.InventoryItems.AsNoTracking().Where(i => !orders.Contains(i.Id))
                .Select(i => i.ToModel()).ToList();
        }

        public static void Create(InventoryItemModel? model)
        {
            if (model is null)
                return;

            DatabaseContext.InventoryItems.Add(model.ToEntity());
            DatabaseContext.SaveChanges();
        }

        public static void Delete(InventoryItemModel? model)
        {
            if (model is null)
                return;

            InventoryItemEntity? entity = DatabaseContext.InventoryItems.AsNoTracking().FirstOrDefault(i => i.Id == model.Id);
            if (entity is null)
                return;
            DatabaseContext.InventoryItems.Remove(entity);
            DatabaseContext.SaveChanges();
        }

        public static void Update(InventoryItemModel? model)
        {
            if (model is null)
                return;

            InventoryItemEntity? entity = DatabaseContext.InventoryItems.FirstOrDefault(i => i.Id == model.Id);
            if (entity is null)
                return;

            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.Size = model.Size;
            entity.Price = model.Price;
            entity.ItemType = model.ItemType;
            DatabaseContext.SaveChanges();
        }
    }
}