using System.ComponentModel;

namespace MedRepairTrack.RequestsForm.Client.Model
{
    public class FullNameModel : INotifyPropertyChanged
    {

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName} {Patronymic}".Trim();
            }

            set
            {
                string[] parts = value.Split(' ');
                if (parts.Length == 3)
                {
                    (FirstName, LastName, Patronymic) = (parts[0], parts[1], parts[2]);
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Patronymic { get; set; } = string.Empty;

        public FullNameModel(string fullname)
        {
            FullName = fullname;
        }

        public FullNameModel(string firstName = "", string lastName = "", string patronymic = "")
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public override string ToString()
        {
            return FullName;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
