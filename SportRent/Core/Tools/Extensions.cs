using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;

namespace SportRent.Core.Tools
{
    public static class Extensions
    {
        public static void Refresh<T>(this ObservableCollection<T> value)
        {
            CollectionViewSource.GetDefaultView(value).Refresh();
        }

        public static string GetDisplayName(this Enum value)
        {
            DisplayDataGridAttribute? attribute = GetCustomDisplayAttribute(value);
            return attribute?.Name ?? value.ToString();
        }

        public static string GetPropertyDisplayName(this PropertyInfo property)
        {
            DisplayDataGridAttribute? attribute = property.GetCustomAttribute<DisplayDataGridAttribute>();
            return attribute?.Name ?? property.Name;
        }

        private static DisplayDataGridAttribute? GetCustomDisplayAttribute(Enum value)
        {
            FieldInfo? field = value.GetType().GetField(value.ToString());
            return field?.GetCustomAttribute<DisplayDataGridAttribute>();
        }

        public static bool IsBlocked(this PropertyInfo property)
        {
            DisplayDataGridAttribute? attribute = property.GetCustomAttribute<DisplayDataGridAttribute>();
            return attribute?.IsBlocked ?? false;
        }

        public static void GenerateDataGrid(this DataGrid dataGrid, object? itemTemplate)
        {
            dataGrid.Columns.Clear();

            if (itemTemplate is null)
                return;

            Type type = itemTemplate.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.IsBlocked())
                    continue;

                dataGrid.Columns.Add(new DataGridTextColumn
                {
                    Header = property.GetPropertyDisplayName(),
                    Binding = new Binding(property.Name),
                });
            }
        }
    }
}
