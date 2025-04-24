using SportRent.Core.Abstractions;
using System.Windows.Controls;

namespace SportRent.Application.Controls
{
    /// <summary>
    /// Interaction logic for SelectControl.xaml
    /// </summary>
    public partial class SelectControl : UserControl
    {
        private ModelBase? _value;

        public event Action<ModelBase?>? OnSelected;
        public IEnumerable<ModelBase>? Models { get; set; }

        public SelectControl()
        {
            InitializeComponent();

            DataContext = this;
        }

        private void SelectClick(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Models is null)
                return;

            SelectorBase selector = new SelectorBase(Models);
            bool result = selector.ShowDialog() ?? false;
            if (!result)
                return;

            _value = selector.SelectedItem;
            SelectedField.Text = _value?.ToString() ?? string.Empty;
            OnSelected?.Invoke(_value);
        }

        public T? GetValue<T>() where T : ModelBase
        {
            return (T?)_value;
        }
    }
}
