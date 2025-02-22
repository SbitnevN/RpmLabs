using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MedRepairTrack.Application.Authentication.Login;
using MedRepairTrack.Application.Authentication.Registration;

namespace MedRepairTrack.Application.Authentication
{
    /// <summary>
    /// Interaction logic for AuthenticationWindow.xaml
    /// </summary>
    public partial class AuthenticationWindow : Window
    {
        private LoginControl _loginControl = new LoginControl();
        private RegistrationControl _registrationControl = new RegistrationControl();

        public AuthenticationWindow()
        {
            InitializeComponent();

            _loginControl.RegistrationButton.Click += RegistrationButton;
            _loginControl.EnterButton.Click += EnterButton;

            _registrationControl.EnterButton.Click += EnterButton;
            _registrationControl.ReturnButton.Click += ReturnButton;

            NavigateTo(_loginControl);
        }

        private void ReturnButton(object sender, RoutedEventArgs e)
        {
            NavigateTo(_loginControl);
        }

        private void RegistrationButton(object sender, RoutedEventArgs e)
        {
            NavigateTo(_registrationControl);
        }

        private void EnterButton(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            mainWindow.Closed += SelfClose;
        }

        private void SelfClose(object? sender, EventArgs e)
        {
           this.Close();
        }

        private void NavigateTo(UserControl userControl)
        {
            MainFrame.Navigate(userControl);
        }
    }
}
