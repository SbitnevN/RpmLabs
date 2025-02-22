using System.Windows;
using System.Collections.ObjectModel;
using MedRepairTrack.Application.UserList.User;
using MedRepairTrack.Application.UserList.User.Model;
using MedRepairTrack.Core.Extensions;

namespace MedRepairTrack.Application.UserList
{
    /// <summary>
    /// Interaction logic for UserListView.xaml
    /// </summary>
    public partial class UserListView : Window
    {
        public ObservableCollection<UserModel> Users { get; } = new ObservableCollection<UserModel>();
        public UserModel SelectedUser => (UserModel)UserList.SelectedItem;

        public UserListView()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void AddNewUser(object sender, RoutedEventArgs e)
        {
            UserModel userModel = new UserModel();
            UserEditor userEditor = new UserEditor(userModel);
            bool result = userEditor.ShowDialog() ?? false;

            if (result)
            {
                Users.Add(userModel);
                Users.Refresh();
            }
        }

        private void EditUser(object sender, RoutedEventArgs e)
        {
            if (UserList.SelectedItem == null)
            {
                return;
            }

            UserModel userModel = (UserModel)UserList.SelectedItem;
            UserEditor userEditor = new UserEditor((UserModel)userModel.Clone());
            
            bool result = userEditor.ShowDialog() ?? false;
            if (result)
            {
                UserList.SelectedItem = userEditor.UserModel;
                Users.Refresh();
            }
        }

        private void SelectUser(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
