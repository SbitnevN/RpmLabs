using SportRent.Application.WorkSpaces.User;
using System.Windows;

namespace SportRent.Application.WorkSpaces
{
    /// <summary>
    /// Логика взаимодействия для SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public SignInWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void EnterButtonClick(object sender, RoutedEventArgs e)
        {
            (bool result, UserModel? model) = UserQuery.TryEnter(Login, Password);
            if (result)
            {
                UserModel.Self = model;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
                return;
            }
            MessageBox.Show("Попробуй еще раз");
        }

        private void RegisterButtonClick(object sender, RoutedEventArgs e)
        {
            CreateAccountWindow createAccountWindow = new CreateAccountWindow();
            createAccountWindow.Show();
        }
    }
}
