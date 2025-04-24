using SportRent.Core.Abstractions;
using SportRent.Core.Tools;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SportRent.Application.Controls
{
    public partial class SelectorBase : Window
    {
        public ModelBase? SelectedItem { get; set; }

        public ObservableCollection<ModelBase> Items { get; } = new ObservableCollection<ModelBase>();

        public SelectorBase(IEnumerable<ModelBase> items)
        {
            InitializeComponent();
            DataContext = this;

            foreach (ModelBase item in items)
                Items.Add(item);
            Items.Refresh();

            Data.GenerateDataGrid(items.FirstOrDefault());
        }

        public void SelectButtonClick(object sender, RoutedEventArgs e)
        {
            int index = Data.SelectedIndex;
            if (index == -1)
                return;

            SelectedItem = (ModelBase)Data.Items[index];
            DialogResult = true;
            Hide();
        }

        public void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Hide();
            DialogResult = false;
        }

        public T? GetSelectedItem<T>() where T : ModelBase
        {
            return (T?)SelectedItem;
        }
    }
}
