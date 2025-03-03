using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using MedRepairTrack.Application.UserList.User.Model;
using MedRepairTrack.Application.UserList.User;
using MedRepairTrack.Core.Extensions;
using MedRepairTrack.Application.UserList.User.Queries;
using MedRepairTrack.Application.EquipmentList.Equipment.Queries;

namespace MedRepairTrack.Application.UserList
{
    /// <summary>
    /// Interaction logic for UserListEditor.xaml
    /// </summary>
    public partial class UserListEditor : UserControl
    {
        public ObservableCollection<UserModel> Users { get; } = new ObservableCollection<UserModel>();
        private UserQueries _userQueries => UserQueries.Instance;

        public UserListEditor()
        {
            InitializeComponent();
            DataContext = this;
            foreach (UserModel user in _userQueries.GetAll())
            {
                Users.Add(user);
            }
        }

        private void AddNewUser(object sender, RoutedEventArgs e)
        {
            UserModel userModel = new UserModel();
            UserEditor userEditor = new UserEditor(userModel);
            bool result = userEditor.ShowDialog() ?? false;

            if (result)
            {
                _userQueries.Add(userModel);
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
                _userQueries.Edit(userEditor.UserModel);
                Users[Users.IndexOf(userModel)] = userEditor.UserModel;
                Users.Refresh();
            }
        }
    }
}
