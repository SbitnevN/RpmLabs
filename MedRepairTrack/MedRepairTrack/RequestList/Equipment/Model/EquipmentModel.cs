namespace MedRepairTrack.Application.RequestList.Equipment.Model
{
    public enum EquipmentType
    {
        Ultrasound,
        Xray,
        Cardiograph
    }

    public class EquipmentModel
    {
        public string Model { get; set; } = string.Empty;

        public EquipmentType Type { get; set; }
    }
}
