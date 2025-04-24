namespace SportRent.Core.Abstractions
{
    internal interface IEntityConvertable<T>
    {
        void FromEntity(T entity);
        T ToEntity();
    }
}