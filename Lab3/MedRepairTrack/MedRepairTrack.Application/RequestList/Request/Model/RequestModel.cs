using MedRepairTrack.Application.EquipmentList.Equipment.Model;
using MedRepairTrack.Application.UserList.User.Model;
using MedRepairTrack.Core.Abstractions;
using MedRepairTrack.Core.Extensions;

namespace MedRepairTrack.Application.RequestList.Request.Model
{
    public enum RequestStatus
    {
        InWork,
        Completed
    }

    public class RequestModel : ViewModelBase, ICloneable, IValidatable
    {
        private UserModel? _user;
        private EquipmentModel? _equipment;

        public Guid Id { get; private set; } = Guid.NewGuid();

        public List<RequestStatus> RequestStatusValues { get; private set; } = Enum.GetValues(typeof(RequestStatus))
            .Cast<RequestStatus>()
            .ToList();

        public Guid Number { get; set; } = Guid.NewGuid();

        public DateTime Date { get; set; } = DateTime.Now;

        public string Description { get; set; } = string.Empty;

        public RequestStatus RequestStatus { get; set; }

        public UserModel? User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public EquipmentModel? Equipment
        {
            get => _equipment;
            set
            {
                _equipment = value;
                OnPropertyChanged();
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{Number}\n{Date}\n{Equipment}\n{Description}\n{User}\n{RequestStatus}";
        }

        public string Validate()
        {
            if (Guid.Empty == Number)
                return "Номер меньше нуля";

            if (Description.IsNullOrEmpty())
                return "Описание не должно быть пустым";

            string errorMessage = string.Empty;
            if (User != null)
            {
                errorMessage = User.Validate();
                if (errorMessage.IsNotEmpty())
                {
                    return errorMessage;
                }
            }

            if (Equipment != null)
            {
                errorMessage = Equipment.Validate();
                if (errorMessage.IsNotEmpty())
                {
                    return errorMessage;
                }
            }

            return string.Empty;
        }
    }
}
