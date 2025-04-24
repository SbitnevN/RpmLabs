using SportRent.Core.Abstractions;
using System.Windows;

namespace SportRent.Application.Controls
{
    public class EditorBase : Window
    {
        public ModelBase? Model { get; set; }
        public bool IsNew { get; set; }
        public bool IsEdit => !IsNew;

        public T? GetModel<T>() where T : ModelBase
        {
            return (T?)Model;
        }

        public void AcceptClick()
        {
            if (Model is null)
                return;

            bool isFail = Model.Validate().IsFail;
            if (isFail)
                return;

            if (IsNew)
                Model.Notify("Успешно создан");

            if (IsEdit)
                Model.Notify("Успешно изменен");

            DialogResult = true;
            Close();
        }

        public void CancelClick()
        {
            DialogResult = false;
            Close();
        }

        public void Show(ModelBase? modelBase = null, bool isNew = true)
        {
            Model = modelBase;
            IsNew = isNew;
            DataContext = Model;
            ShowDialog();
        }
    }
}
