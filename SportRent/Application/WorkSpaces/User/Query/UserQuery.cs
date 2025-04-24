using Microsoft.EntityFrameworkCore;
using SportRent.Application.WorkSpaces.Order;
using SportRent.Database;

namespace SportRent.Application.WorkSpaces.User
{
    public static class UserQuery
    {
        private static DatabaseContext DatabaseContext = DatabaseContext.Instance;

        public static IEnumerable<UserModel> GetAll()
        {
            return DatabaseContext.Users.AsNoTracking().Select(u => u.ToModel()).ToList();
        }

        public static void Create(UserModel? model)
        {
            if (model is null)
                return;

            DatabaseContext.Users.Add(model.ToEntity());
            DatabaseContext.SaveChanges();
        }

        public static void Update(UserModel? model)
        {
            if (model is null)
                return;

            UserEntity? entity = DatabaseContext.Users.FirstOrDefault(o => o.Id == model.Id);
            if (entity is null)
                return;

            entity.Login = model.Login;
            entity.Password = model.Password;
            entity.Name = model.Name;
            entity.Role = model.Role;
            DatabaseContext.SaveChanges();
        }

        public static void Delete(UserModel? model)
        {
            if (model is null)
                return;

            UserEntity? entity = DatabaseContext.Users.AsNoTracking().FirstOrDefault(e => e.Id == model.Id);
            if (entity is null)
                return;
            DatabaseContext.Users.Remove(entity);
            DatabaseContext.SaveChanges();
        }

        public static (bool, UserModel?) TryEnter(string login, string password)
        {
            UserEntity? entity = DatabaseContext.Users.FirstOrDefault(e => e.Login == login && e.Password == password);
            return (entity is not null, entity?.ToModel());
        }
    }
}