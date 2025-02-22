using System.Windows;
using MedRepairTrack.Application.RequestList.Request.Model;
using MedRepairTrack.Application.UserList.User.Model;
using MedRepairTrack.Core.Extensions;


namespace MedRepairTrack.Application.UserList.User
{
    /// <summary>
    /// Interaction logic for UserEditor.xaml
    /// </summary>
    public partial class UserEditor : Window
    {
        public UserModel UserModel { get; set; }

        public UserEditor(UserModel userModel)
        {
            InitializeComponent();
            UserModel = userModel;
            DataContext = UserModel;
        }

        private void AcceptClick(object sender, RoutedEventArgs e)
        {
            string errorMessage = UserModel.Validate();
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
