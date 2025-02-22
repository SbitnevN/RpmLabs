using System.Text.RegularExpressions;
using MedRepairTrack.Core.Abstractions;

namespace MedRepairTrack.Application.UserList.User.Model
{
    public class UserModel : ICloneable, IValidatable
    {
        private const string PhonePattern = @"(\+7|8|\b)[\(\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[)\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)";

        public Guid Id { get; set; } = Guid.NewGuid();

        public string FullName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{FullName} - {Phone}";
        }

        public string Validate()
        {
            int fullnameLenght = FullName.Trim().Split().Length;
            if (fullnameLenght < 2)
                return "ФИО должно содержать как минимум фамилию и имя";

            if (fullnameLenght > 3)
                return "У вас слишком большое ФИО";

            if (Regex.IsMatch(Phone, PhonePattern) == false)
                return "Неверный формат телефона";

            return "";
        }
    }
}
