using System.ComponentModel.DataAnnotations;

namespace SportRent.Application.WorkSpaces.User
{
    public class UserEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Role Role { get; set; } = Role.User;

        public string Password { get; set; } = string.Empty;

        public string Login { get; set; } = string.Empty;

        public UserModel ToModel()
        {
            UserModel model = new UserModel();
            model.Id = Id;
            model.Name = Name;
            model.Role = Role;
            model.Password = Password;
            model.Login = Login;
            return model;
        }
    }
}