namespace SportRent.Core.Abstractions
{
    public interface INotifiable
    {
        public void ChangeNotify();
        public void Notify(string message);
    }
}