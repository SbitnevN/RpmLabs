using MedRepairTrack.Core.DataAccess.Entities;
using MedRepairTrack.Core.DataAccess;
using MedRepairTrack.Application.UserList.User.Model;
using System.Data.Entity;

namespace MedRepairTrack.Application.UserList.User.Queries
{
    public class UserQueries
    {
        private UserQueries() { }
        private DatabaseContext _dataBaseContext => DatabaseContext.Instance;
        public static readonly UserQueries Instance = new UserQueries();

        public void Add(UserModel userModel)
        {
            UserEntity userEntity = new UserEntity()
            {
                Id = userModel.Id,
                Phone = userModel.Phone,
                FullName = userModel.FullName,
            };

            _dataBaseContext.Users.Add(userEntity);
            _dataBaseContext.SaveChanges();
        }

        public IList<UserModel> GetAll()
        {
            IList<UserModel> result = _dataBaseContext.Users.AsNoTracking().Select(e => new UserModel()
            {
                Id = e.Id,
                FullName = e.FullName,
                Phone = e.Phone
            }).ToList();

            return result;
        }

        public void Edit(UserModel userModel)
        {
            UserEntity? userEntity = _dataBaseContext.Users.AsNoTracking().FirstOrDefault(e => e.Id == userModel.Id);

            if (userEntity == null)
            {
                Add(userModel);
                return;
            }

            userEntity.Phone = userEntity.Phone;
            userEntity.FullName = userEntity.FullName;

            _dataBaseContext.SaveChanges();
        }
    }
}
