using Microsoft.EntityFrameworkCore;
using SportRent.Application.WorkSpaces.User;
using SportRent.Database;

namespace SportRent.Application.WorkSpaces.Order
{
    public static class OrderQuery
    {
        private static DatabaseContext DatabaseContext = DatabaseContext.Instance;

        public static IEnumerable<OrderModel> GetAll()
        {
            return DatabaseContext.Orders.Include(o => o.User)
                .Include(o => o.InventoryItem).AsNoTracking().Select(o => o.ToModel()).ToList();
        }

        public static IEnumerable<OrderModel> GetSelf()
        {
            Guid? SelfId = UserModel.Self?.Id;
            return DatabaseContext.Orders.Include(o => o.User)
                .Include(o => o.InventoryItem).AsNoTracking().Where(o => o.UserId == SelfId).Select(o => o.ToModel()).ToList();
        }

        public static void Create(OrderModel? model)
        {
            if (model is null)
                return;

            DatabaseContext.Orders.Add(model.ToEntity());
            DatabaseContext.SaveChanges();
        }

        public static void Update(OrderModel? model)
        {
            if (model is null)
                return;

            OrderEntity? entity = DatabaseContext.Orders.FirstOrDefault(o => o.Id == model.Id);
            if (entity is null)
                return;

            entity.EndDate = model.EndDate;
            entity.UserId = model.UserId;
            entity.InventoryItemId = model.InventoryItemId;
            DatabaseContext.SaveChanges();
        }

        public static void Delete(OrderModel? model)
        {
            if (model is null)
                return;
            OrderEntity? entity = DatabaseContext.Orders.AsNoTracking().FirstOrDefault(e => e.Id == model.Id);
            if (entity is null)
                return;
            DatabaseContext.Orders.Remove(entity);
            DatabaseContext.SaveChanges();
        }

        public static decimal GetDiscount()
        {
            if (UserModel.Self?.Id is null)
                return 0;

            IEnumerable<OrderEntity> orders = DatabaseContext.Orders.AsNoTracking()
                .Where(o => o.UserId == UserModel.Self.Id).ToList();

            decimal discount = orders.Count() * 2;
            if (discount > 40)
                discount = 40;
            if (DateTime.Now.Month == 12 && DateTime.Now.Month == 1 && DateTime.Now.Month == 2)
                discount -= 40;

            return discount;
        }
    }
}