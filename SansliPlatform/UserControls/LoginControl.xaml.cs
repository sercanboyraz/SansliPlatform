using System.Windows;
using System.Windows.Controls;

namespace SansliPlatform.UserControls
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        TextBox textBox = null;
        PasswordBox passwordText = null;
        public LoginControl()
        {
            InitializeComponent();
            this.Loaded += LoginControl_Loaded;
        }

        private void LoginControl_Loaded(object sender, RoutedEventArgs e)
        {
            textBox = txtBayiino; 
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            if (txtBayiino.Text.Length == 6 && txtPassword.Password.Length == 6)
            {
                var w = (MainWindow)System.Windows.Application.Current.MainWindow;
                w.isLoginTabActivated();
            }
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (textBox != null && textBox.Text.Length <= 5)
                textBox.Text += button.Content.ToString();
            if (passwordText != null && passwordText.Password.Length <= 5)
                passwordText.Password += button.Content.ToString();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (textBox != null)
            {
                string s = textBox.Text;
                if (s.Length > 1)
                {
                    s = s.Substring(0, s.Length - 1);
                }
                else
                {
                    s = "";
                }
                textBox.Text = s;
            }
            if (passwordText != null)
            {
                string s = passwordText.Password;
                if (s.Length > 1)
                {
                    s = s.Substring(0, s.Length - 1);
                }
                else
                {
                    s = "";
                }
                passwordText.Password = s;
            }

        }

        private void bayiNo_Button_Click(object sender, RoutedEventArgs e)
        {
            textBox = (TextBox)sender;
            passwordText = null;
        }

        private void password_Button_Click(object sender, RoutedEventArgs e)
        
        {
            passwordText = (PasswordBox)sender;
            textBox = null;
        }

    }
}
