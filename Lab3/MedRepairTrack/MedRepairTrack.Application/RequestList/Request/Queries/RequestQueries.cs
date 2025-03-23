using MedRepairTrack.Application.EquipmentList.Equipment.Model;
using MedRepairTrack.Application.EquipmentList.Equipment.Queries;
using MedRepairTrack.Core.DataAccess.Entities;
using MedRepairTrack.Core.DataAccess;
using MedRepairTrack.Application.RequestList.Request.Model;
using System.Data.Entity;
using MedRepairTrack.Application.UserList.User.Model;

namespace MedRepairTrack.Application.RequestList.Request.Queries
{
    public class RequestQueries
    {
        private RequestQueries() { }

        public static readonly RequestQueries Instance = new RequestQueries();

        private DatabaseContext _dataBaseContext => DatabaseContext.Instance;

        public void Add(RequestModel requestModel)
        {
            RequestEntity requestEntity = new RequestEntity()
            {
                Number = requestModel.Number,
                Description = requestModel.Description,
                EquipmentId = requestModel.Equipment?.Id,
                UserId = requestModel.User?.Id,
                Date = requestModel.Date
            };

            _dataBaseContext.Requests.Add(requestEntity);
            _dataBaseContext.SaveChanges();
        }

        public IList<RequestModel> GetAll()
        {

            IList<RequestModel> result = _dataBaseContext.Requests
                .Include(r => r.User)
                .Include(r => r.Equipment)
                .Select(r => new RequestModel()
                    {
                        Number = r.Number,
                        Equipment = EquipmentModel.FromEntity(r.Equipment),
                        User = UserModel.FromEntity(r.User),
                        Date = r.Date,
                        Description = r.Description
                    }
                ).AsNoTracking().ToList();

            return result;
        }

        public void Edit(RequestModel requestModel)
        {
            var requestEntity = _dataBaseContext.Requests
                .AsNoTracking()
                .FirstOrDefault(r => r.Number == requestModel.Number);

            if (requestEntity == null)
            {
                Add(requestModel);
                return;
            }


            UserEntity? existingUser = _dataBaseContext.Users
                .Local
                .FirstOrDefault(u => u.Id == requestModel.User?.Id);

            if (existingUser != null)
            {
                requestEntity.User = existingUser;
            }
            else
            {
                requestEntity.User = UserModel.ToEntity(requestModel.User);
                if (requestEntity.User != null)
                {
                    _dataBaseContext.Users.Attach(requestEntity.User);
                }
            }

            requestEntity.Number = requestModel.Number;
            requestEntity.Date = requestModel.Date;
            requestEntity.Description = requestModel.Description;

            _dataBaseContext.Requests.Update(requestEntity);
            _dataBaseContext.SaveChanges();

        }
    }
}
