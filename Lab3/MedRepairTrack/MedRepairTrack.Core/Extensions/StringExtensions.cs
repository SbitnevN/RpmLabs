using System.Collections.ObjectModel;
using System.Windows.Data;

namespace MedRepairTrack.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsEmpty(this string value)
        {
            return string.Empty == value;   
        }

        public static bool IsNotEmpty(this string value)
        {
            return !value.IsEmpty();
        }
    }
}
