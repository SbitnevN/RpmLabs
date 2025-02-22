using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using MedRepairTrack.Application.EquipmentList.Equipment.Model;
using MedRepairTrack.Core.Extensions;


namespace MedRepairTrack.Application.EquipmentList
{
    /// <summary>
    /// Interaction logic for UserListEditor.xaml
    /// </summary>
    public partial class EquipmentListEditor : UserControl
    {
        public ObservableCollection<EquipmentModel> Equipments { get; } = new ObservableCollection<EquipmentModel>();

        public EquipmentListEditor()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void AddNewUser(object sender, RoutedEventArgs e)
        {
            EquipmentModel model = new EquipmentModel();
            EquipmentEditor editor = new EquipmentEditor(model);
            bool result = editor.ShowDialog() ?? false;

            if (result)
            {
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
                Equipments[Equipments.IndexOf(model)] = editor.EquipmentModel;
                Equipments.Refresh();
            }
        }
    }
}
