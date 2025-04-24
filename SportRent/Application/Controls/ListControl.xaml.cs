using SportRent.Core.Abstractions;
using SportRent.Core.Tools;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace SportRent.Application.Controls
{
    public partial class ListControl : UserControl
    {
        private EditorBase? _editorTemplate;
        private ModelBase? _emptyModel;
        private EditorBase? Editor
        {
            get
            {
                if (_editorTemplate is null)
                    return null;
                return (EditorBase?)Activator.CreateInstance(_editorTemplate.GetType());
            }
        }

        public event Action<ModelBase?>? OnRemoveItem;
        public event Action<ModelBase?>? OnAddItem;
        public event Action<ModelBase?>? OnChangeItem;

        public ObservableCollection<ModelBase> Items { get; } = new ObservableCollection<ModelBase>();

        public ListControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void ChangeButtonClick(object sender, RoutedEventArgs e)
        {
            EditorBase? editor = Editor;
            if (editor is null)
                return;

            ModelBase? model = GetSelectedItem();
            if (model is null)
                return;

            ModelBase clone = model.Clone<ModelBase>();

            editor.Show(clone, false);

            bool result = (editor.DialogResult ?? false);

            if (result)
            {
                model = editor?.Model; 
                OnChangeItem?.Invoke(model);
                model?.ChangeNotify();

                if (model is not null)
                    ReplaceSelectedItem(model);
            }
        }

        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            ModelBase? model = GetSelectedItem();
            if (model is null)
                return;

            Items.Remove(model);
            Items.Refresh();
            OnRemoveItem?.Invoke(model);
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            EditorBase? editor = Editor;
            if (editor is null)
                return;

            ModelBase? model = _emptyModel?.Clone<ModelBase>();

            editor.Show(model);

            bool result = editor.DialogResult ?? false;
            if (result)
            {
                OnAddItem?.Invoke(model);
                if (model is null)
                    return;
                Items.Add(model);
                Items.Refresh();
            }
            Data.GenerateDataGrid(model);
        }

        public void Load(IEnumerable<ModelBase> models, EditorBase editor, ModelBase emptyModel)
        {
            Items.Clear();
            Data.GenerateDataGrid(models.FirstOrDefault());

            foreach (ModelBase model in models)
                Items.Add(model);
            Items.Refresh();

            _editorTemplate = editor;
            _emptyModel = emptyModel;
        }

        private ModelBase? GetSelectedItem()
        {
            int index = Data.SelectedIndex;
            if (index == -1)
                return null;

            if (Data.Items[index] is ModelBase)
                return (ModelBase)Data.Items[index];

            return null;
        }

        private void ReplaceSelectedItem(ModelBase model)
        {
            int index = Data.SelectedIndex;
            if (index == -1)
                return;

            Items[index] = model;
            Items.Refresh();
        }
    }
}
