using System.Windows;
using MedRepairTrack.Application.EquipmentList;
using MedRepairTrack.Application.RequestList;
using MedRepairTrack.Application.UserList;

namespace MedRepairTrack.Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenRequestList(object sender, RoutedEventArgs e)
        {
            RequestListEditor requestList = new RequestListEditor();
            MainFrame.Navigate(requestList);
        }

        private void OpenUserList(object sender, RoutedEventArgs e)
        {
            UserListEditor userListView = new UserListEditor();
            MainFrame.Navigate(userListView);
        }

        private void OpenEquipmentList(object sender, RoutedEventArgs e)
        {
            EquipmentListEditor equipmentListView = new EquipmentListEditor();
            MainFrame.Navigate(equipmentListView);
        }
    }
}