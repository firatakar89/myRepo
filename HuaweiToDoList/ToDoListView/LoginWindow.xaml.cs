using Controller.Controllers;
using Data.Model;
using System.Windows;

namespace ToDoListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        UserController userController;
        public LoginWindow()
        {
            InitializeComponent();
             userController = new UserController();
            
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
              
           User loggedInUser = userController.Login(new User(usernameTxt.Text, passwordTxt.Password));
            login(loggedInUser);
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            User new_user = new User(usernameTxt.Text, passwordTxt.Password);
          
                if (userController.Register(new_user))
                {
                    login(userController.Login(new_user));

                }
                else {
                    loginStatus.Content = "Kayıt işlemi başarısız";

                }
           

        }

        private void login(User loggedInUser)
        {
            if (loggedInUser != null)
            {
                MainWindow main = new MainWindow(loggedInUser);
                App.Current.MainWindow = main;
                this.Close();
                main.Show();
            }
        }
    }
}
