using SportRent.Application.Controls;
using SportRent.Application.WorkSpaces.InventoryItem;
using SportRent.Application.WorkSpaces.InventoryItem.Query;
using SportRent.Application.WorkSpaces.User;
using SportRent.Core.Abstractions;
using System.Windows;

namespace SportRent.Application.WorkSpaces.Order
{
    public partial class OrderEditor : EditorBase
    {
        public OrderEditor()
        {
            InitializeComponent();
            SelectInventory.Models = InventoryItemQuery.GetFree();
            SelectInventory.OnSelected += OnSelectedItem;
        }

        private void AcceptButtonClick(object sender, RoutedEventArgs e)
        {
            OrderModel? order = GetModel<OrderModel>();
            if (order != null)
            {
                order.UserId = UserModel.Self?.Id;
                order.User = UserModel.Self;
            }
                
            AcceptClick();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            CancelClick();
        }

        private void OnSelectedItem(ModelBase? model)
        {
            if (model is null)
                return;

            OrderModel? order = GetModel<OrderModel>();

            if (order is null)
                return;

            InventoryItemModel inventoryItemModel = (InventoryItemModel)model;
            order.InventoryItemId = inventoryItemModel.Id;
            order.InventoryItem = inventoryItemModel;

            if (order.EndDate is null)
                return;

            decimal totalPrice = (decimal)(DateTime.Now - order.EndDate.Value).TotalDays * inventoryItemModel.Price;
            decimal discount = OrderQuery.GetDiscount();
            totalPrice -= discount / 100 * totalPrice;
            Price.Text = $"Цена: {totalPrice}";
        }
    }
}
