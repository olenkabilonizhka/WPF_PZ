using System.Windows;
using System.Windows.Controls;
using Unity;

namespace AdminWPF
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage(LoginViewModel lvm)
        {
            InitializeComponent();
            DataContext = lvm;

            Loaded += Login_Load;
        }

        private void Login_Load(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel lvm)
            {
                lvm.LoginSuccess += () =>
                {
                    StartPage sp = App.container.Resolve<StartPage>();
                    sp.Show();
                    Close();
                };
                lvm.LoginFailed += () =>
                {
                    MessageBox.Show("No access!", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                    Application.Current.Shutdown();
                };
                lvm.Exit += () =>
                {
                    Application.Current.Shutdown();
                };
            }
        }

        private void PasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(DataContext != null)
            {
                ((dynamic)DataContext).Password = ((PasswordBox)sender).Password;
            }
        }
    }
}
