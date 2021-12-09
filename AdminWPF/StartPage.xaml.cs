using System.Windows;
using Unity;

namespace AdminWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StartPage : Window
    {
        LoginViewModel loginVM;

        public StartPage(MainViewModel mainVM, LoginViewModel loginVM)
        {
            DataContext = mainVM;
            this.loginVM = loginVM;
            InitializeComponent();

            Loaded += StartPage_Loaded;
        }

        private void StartPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainViewModel mvm)
            {
                mvm.LogOut += () =>
                {
                    LoginPage lp = new LoginPage(loginVM);
                    lp.Show();
                    Close();
                };
            }
        }
    }
}
