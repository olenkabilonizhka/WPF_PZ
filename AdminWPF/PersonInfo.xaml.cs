using System.Windows;

namespace AdminWPF
{
    /// <summary>
    /// Interaction logic for PersonInfo.xaml
    /// </summary>
    public partial class PersonInfo : Window
    {
        public PersonInfo(PersonInfoViewModel personVM)
        {
            DataContext = personVM;
            InitializeComponent();

            LoadFields(personVM);

            Loaded += PersonInfo_Loaded;
        }

        private void LoadFields(PersonInfoViewModel personVM)
        {
            if(personVM.PersonV.isEmpty())
            {
                PersonidLabel.Visibility = Visibility.Hidden;
                PersonIdTextBox.Visibility = Visibility.Hidden;
                StatusLabel.Visibility = Visibility.Hidden;
                StatusTextBox.Visibility = Visibility.Hidden;
            }
            else
            {
                PasswrdTextBox.Text = "********";
            }
        }

        private void PersonInfo_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is PersonInfoViewModel pvm)
            {
                pvm.Saved += () =>
                {
                    DialogResult = true;
                    Close();
                };
                pvm.Closed += () =>
                {
                    DialogResult = false;
                    Close();
                };
            }
        }
    }
}
