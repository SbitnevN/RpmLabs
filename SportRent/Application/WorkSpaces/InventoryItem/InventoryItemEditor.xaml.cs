using SportRent.Application.Controls;
using SportRent.Application.WorkSpaces.InventoryItem.Query;
using SportRent.Core.Abstractions;
using System.Windows;

namespace SportRent.Application.WorkSpaces.InventoryItem
{
    public partial class InventoryItemEditor : EditorBase
    {
        public InventoryItemEditor() : base()
        {
            InitializeComponent();
        }

        private void AcceptButtonClick(object sender, RoutedEventArgs e)
        {
            AcceptClick();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            CancelClick();
        }
    }
}
