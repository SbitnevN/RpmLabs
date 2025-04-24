using SportRent.Application.Controls;

namespace SportRent.Application.WorkSpaces.User
{
    public partial class UserEditor : EditorBase
    {
        public UserEditor()
        {
            InitializeComponent();
        }

        private void AcceptButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            AcceptClick();
        }

        private void CancelButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            CancelClick();
        }
    }
}
