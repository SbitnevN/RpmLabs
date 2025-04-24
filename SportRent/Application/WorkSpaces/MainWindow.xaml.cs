using SportRent.Application.Controls;
using SportRent.Application.WorkSpaces.InventoryItem;
using SportRent.Application.WorkSpaces.InventoryItem.Query;
using SportRent.Application.WorkSpaces.Order;
using SportRent.Application.WorkSpaces.User;
using SportRent.Core.Tools;
using System.Windows;

namespace SportRent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Users.Visibility = (UserModel.Self?.Role == Role.Admin) ? Visibility.Visible : Visibility.Hidden;
        }

        private void InventoryClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(ConfigureOrder());
        }

        private void CatalogClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(ConfigureInventory());
        }

        private void UsersClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(ConfigureUsers());
        }

        private ListControl ConfigureOrder()
        {
            ListControl orders = new ListControl();
            OrderEditor orderEditor = new OrderEditor();
            IEnumerable<OrderModel> models = OrderQuery.GetSelf();
            orders.Load(models, orderEditor, new OrderModel());

            orders.OnAddItem += model => 
            { 
                OrderQuery.Create((OrderModel?)model);
                orders.Items.Refresh();
            };
            orders.OnChangeItem += model => 
            {
                OrderQuery.Update((OrderModel?)model);
                orders.Items.Refresh();
            };
            orders.OnRemoveItem += model =>
            {
                OrderQuery.Delete((OrderModel?)model);
                orders.Items.Refresh();
            };

            orders.ChangeButton.Visibility = Visibility.Hidden;

            return orders;
        }

        private ListControl ConfigureInventory()
        {
            ListControl inventory = new ListControl();
            InventoryItemEditor inventoryEditor = new InventoryItemEditor();
            IEnumerable<InventoryItemModel> models = InventoryItemQuery.GetFree();
            inventory.Load(models, inventoryEditor, new InventoryItemModel());

            inventory.OnAddItem += model =>
            {
                InventoryItemQuery.Create((InventoryItemModel?)model);
                inventory.Items.Refresh();
            };
            inventory.OnChangeItem += model =>
            {
                InventoryItemQuery.Update((InventoryItemModel?)model);
                inventory.Items.Refresh();
            };
            inventory.OnRemoveItem += model =>
            {
                InventoryItemQuery.Delete((InventoryItemModel?)model);
                inventory.Items.Refresh();
            };

            inventory.AddButton.Visibility = (UserModel.Self?.Role == Role.Admin) ? Visibility.Visible : Visibility.Hidden;
            inventory.ChangeButton.Visibility = (UserModel.Self?.Role == Role.Admin) ? Visibility.Visible : Visibility.Hidden;
            inventory.RemoveButton.Visibility = (UserModel.Self?.Role == Role.Admin) ? Visibility.Visible : Visibility.Hidden;

            return inventory;
        }

        private ListControl ConfigureUsers()
        {
            ListControl users = new ListControl();
            UserEditor userEditor = new UserEditor();
            IEnumerable<UserModel> models = UserQuery.GetAll();
            users.Load(models, userEditor, new UserModel());

            users.OnAddItem += model =>
            {
                UserQuery.Create((UserModel?)model);
                users.Items.Refresh();
            };
            users.OnChangeItem += model =>
            {
                UserQuery.Update((UserModel?)model);
                users.Items.Refresh();
            };
            users.OnRemoveItem += model =>
            {
                UserQuery.Delete((UserModel?)model);
                users.Items.Refresh();
            };

            return users;
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                if (window != this)
                {
                    window.Close();
                }
            }
        }
    }
}