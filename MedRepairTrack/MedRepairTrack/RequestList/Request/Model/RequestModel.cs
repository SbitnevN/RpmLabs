using MedRepairTrack.RequestsForm.Client.Model;

namespace MedRepairTrack.RequestsForm.Request.Model
{
    public enum RequestStatus
    {
        InWait,
        InProcess,
        Completed
    }

    public class RequestModel
    {
        public Guid Uid { get; private set; } = Guid.NewGuid();

        public long Number { get; set; } = 0; // todo потом из базы возьмем

        public string Description { get; set; } = string.Empty;

        public DateTime Date { get; set; } = DateTime.Now;

        public ClientModel Client { get; set; } = new ClientModel();

        public RequestModel(string description, ClientModel client, DateTime date)
        {
            Description = description;
            Date = date;
            Client = client;
        }

        public RequestModel(string description, ClientModel client)
        {
            Description = description;
            Date = DateTime.Now;
            Client = client;
        }

        public RequestModel()
        {
        }

        public override string ToString()
        {
            return $"{Number}\n{Description}\n{Client}\n{Date}";
        }
    }
}
