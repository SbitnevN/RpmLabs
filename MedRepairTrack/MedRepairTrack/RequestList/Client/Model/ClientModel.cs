using System.ComponentModel;

namespace MedRepairTrack.RequestsForm.Client.Model
{
    public class ClientModel : INotifyPropertyChanged
    {
        public Guid Uid { get; private set; } = Guid.NewGuid();

        private string phoneNumber = string.Empty;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (phoneNumber != value)
                {
                    phoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        public FullNameModel FullName { get; set; }

        public ClientModel(string fullname, string phoneNumber)
        {
            FullName = new FullNameModel(fullname);
            PhoneNumber = phoneNumber;
        }

        public ClientModel()
        {
            FullName = new FullNameModel();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public override string ToString()
        {
            return $"{FullName} - тел. {PhoneNumber}";
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
