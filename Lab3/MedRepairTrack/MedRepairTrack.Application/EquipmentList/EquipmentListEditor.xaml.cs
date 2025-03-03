using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using MedRepairTrack.Application.EquipmentList.Equipment.Model;
using MedRepairTrack.Application.EquipmentList.Equipment.Queries;
using MedRepairTrack.Core.Extensions;


namespace MedRepairTrack.Application.EquipmentList
{
    /// <summary>
    /// Interaction logic for UserListEditor.xaml
    /// </summary>
    public partial class EquipmentListEditor : UserControl
    {
        public ObservableCollection<EquipmentModel> Equipments { get; } = new ObservableCollection<EquipmentModel>();
        private EquipmentQueries _equipmentQueries => EquipmentQueries.Instance;

        public EquipmentListEditor()
        {
            InitializeComponent();
            DataContext = this;
            foreach (EquipmentModel equipmentModel in _equipmentQueries.GetAll())
            {
                Equipments.Add(equipmentModel);
            }
            Equipments.Refresh();
        }

        private void AddNewUser(object sender, RoutedEventArgs e)
        {
            EquipmentModel model = new EquipmentModel();
            EquipmentEditor editor = new EquipmentEditor(model);
            bool result = editor.ShowDialog() ?? false;

            if (result)
            {
                _equipmentQueries.Add(model);
                Equipments.Add(model);
                Equipments.Refresh();
            }
        }

        private void EditUser(object sender, RoutedEventArgs e)
        {
            if (EquipmentList.SelectedItem == null)
            {
                return;
            }

            EquipmentModel model = (EquipmentModel)EquipmentList.SelectedItem;
            EquipmentEditor editor = new EquipmentEditor((EquipmentModel)model.Clone());

            bool result = editor.ShowDialog() ?? false;
            if (result)
            {
                _equipmentQueries.Edit(editor.EquipmentModel);
                Equipments[Equipments.IndexOf(model)] = editor.EquipmentModel;
                Equipments.Refresh();
            }
        }
    }
}
