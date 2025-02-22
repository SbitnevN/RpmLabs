using System.Windows;
using MedRepairTrack.Core.Extensions;

namespace MedRepairTrack.Application.EquipmentList.Equipment.Model
{
    /// <summary>
    /// Interaction logic for EquipmentEditor.xaml
    /// </summary>
    public partial class EquipmentEditor : Window
    {
        public EquipmentModel EquipmentModel { get; set; }

        public EquipmentEditor(EquipmentModel equipmentModel)
        {
            InitializeComponent();
            EquipmentModel = equipmentModel;
            DataContext = EquipmentModel;
        }

        private void AcceptClick(object sender, RoutedEventArgs e)
        {
            string errorMessage = EquipmentModel.Validate();
            if (errorMessage.IsNotEmpty())
            {
                MessageBox.Show(errorMessage, "Ашибка");
                return;
            }

            DialogResult = true;
            Close();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
