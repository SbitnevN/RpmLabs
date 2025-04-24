using SportRent.Application.WorkSpaces.InventoryItem;
using SportRent.Core.Abstractions;
using SportRent.Core.Tools;

namespace SportRent.Application.WorkSpaces.User
{
    public enum Role
    {
        Admin,
        User
    }

    public class UserModel : ModelBase
    {
        [DisplayDataGrid(IsBlocked = true)]
        public static UserModel? Self { get; set; }

        [DisplayDataGrid(IsBlocked = true)]
        public IEnumerable<Role> RoleValues { get; private set; } = Enum.GetValues(typeof(Role)).Cast<Role>().ToList();

        [DisplayDataGrid(IsBlocked = true)]
        public Guid Id { get; set; } = Guid.NewGuid();

        [DisplayDataGrid("Имя")]
        public string Name { get; set; } = string.Empty;

        [DisplayDataGrid("Логин")]
        public string Login { get; set; } = string.Empty;

        [DisplayDataGrid("Роль")]
        public Role Role { get; set; } = Role.User;

        [DisplayDataGrid(IsBlocked = true)]
        public string Password { get; set; } = string.Empty;

        public UserEntity ToEntity()
        {
            UserEntity entity = new UserEntity();
            entity.Id = Id;
            entity.Name = Name;
            entity.Login = Login;
            entity.Password = Password;
            entity.Role = Role;
            return entity;
        }

        public override ValidateResult Validate()
        {
            ValidateResult result = new ValidateResult();
            if (string.IsNullOrEmpty(Name))
                result.Message = "Имя не должно быть пустым";

            if (string.IsNullOrEmpty(Login))
                result.Message = "Логин нормально сделай";

            if (Password.Contains(' '))
                result.Message = "Пароль с пробелом";

            if (Password.Length < 8)
                result.Message = "Пароль короткий";

            if (result.IsFail)
                Notify(result.Message);
            return result;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}