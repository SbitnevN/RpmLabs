namespace SportRent.Core.Abstractions
{
    public interface ICustomClonable
    {
        public T Clone<T>();
    }
}