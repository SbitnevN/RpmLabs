namespace SportRent.Core.Tools
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class DisplayDataGridAttribute : Attribute
    {
        public string Name { get; set; }
        public bool IsBlocked { get; set; }

        public DisplayDataGridAttribute(string name = "", bool isBlocked = false)
        {
            Name = name;
            IsBlocked = isBlocked;
        }
    }
}
