using System.Windows;

namespace SportRent.Core.Abstractions
{
    public class ModelBase : IValidatable, INotifiable, ICustomClonable
    {
        private const string SuccessfulChanges = "Успешно изменен";

        public void ChangeNotify()
        {
            Notify(SuccessfulChanges);
        }

        public T Clone<T>()
        {
            return (T)MemberwiseClone();
        }

        public void Notify(string message)
        {
            MessageBox.Show(message);
        }

        public virtual ValidateResult Validate()
        {
            return default;
        }
    }
}