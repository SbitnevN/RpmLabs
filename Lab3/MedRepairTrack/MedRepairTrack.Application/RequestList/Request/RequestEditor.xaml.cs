using System.Windows;
using System.Windows.Navigation;
using MedRepairTrack.Application.EquipmentList;
using MedRepairTrack.Application.RequestList.Request.Model;
using MedRepairTrack.Application.UserList;
using MedRepairTrack.Core.Abstractions;
using MedRepairTrack.Core.Extensions;

namespace MedRepairTrack.Application.RequestList.Request
{
    /// <summary>
    /// Interaction logic for RequestEditor.xaml
    /// </summary>
    public partial class RequestEditor : Window
    {
        private FormState _formState;
        public RequestModel RequestModel { get; set; }

        public bool IsCreate => _formState == FormState.Create;

        public RequestEditor(RequestModel requestModel, FormState formState = FormState.Create)
        {
            InitializeComponent();
            RequestModel = requestModel;
            DataContext = RequestModel;
            _formState = formState;
        }

        private void SelectUser(object sender, RoutedEventArgs e)
        {
            UserListView userListView = new UserListView();
            if (userListView.ShowDialog() ?? false)
            {
                RequestModel.User = userListView.SelectedUser;
            }
        }

        private void SelectEquipment(object sender, RoutedEventArgs e)
        {
            EquipmentListView equipmentListView = new EquipmentListView();
            if (equipmentListView.ShowDialog() ?? false)
            {
                RequestModel.Equipment = equipmentListView.SelectedEquipment;
            }
        }

        private void AcceptClick(object sender, RoutedEventArgs e)
        {
            string errorMessage = RequestModel.Validate();
            if (errorMessage.IsNotEmpty())
            {
                MessageBox.Show(errorMessage, "Ашибка");
                return;
            }

            DialogResult = true;
            Close();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
