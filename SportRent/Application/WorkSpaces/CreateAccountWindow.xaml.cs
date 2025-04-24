using SportRent.Application.WorkSpaces.User;
using System.Windows;

namespace SportRent.Application.WorkSpaces
{
    /// <summary>
    /// Логика взаимодействия для CreateAccountWindow.xaml
    /// </summary>
    public partial class CreateAccountWindow : Window
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;

        public CreateAccountWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            UserModel model = new UserModel()
            {
                Login = Login,
                Password = Password,
                Name = Username
            };

            if (model.Validate().IsSuccess)
            {
                UserQuery.Create(model);
                Close();
                model.Notify("Успех!");
            }
        }
    }
}
