using Controller.Controllers;
using Data.Model;
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

namespace ToDoListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Logged in user
        User user;
        ToDoListController toDoListController;
        ToDoList selectedList;
        public MainWindow(User user)
        {
            this.user = user;
            InitializeComponent();
            toDoListController = new ToDoListController();
            UserNameStatusBarText.Content = this.user.username;
            InitializeLeftMenu();

        }
        private void InitializeLeftMenu()
        {

            List<ToDoList> myLists = toDoListController.List(user);
            myListsListView.Items.Clear();
            foreach (ToDoList myList in myLists)
            {
                myListsListView.Items.Add(myList.name);
            }
            
        }

        private void newListBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(newListTxt.Text))
                {
                    
                    
                    toDoListController.Add(newListTxt.Text,user);
                    InitializeLeftMenu();
                }
                else {
                    TransactionStatusBarText.Content = "Liste Adı boş bırakılamaz";

                }
            }
            catch (Exception Ex)
            {
                TransactionStatusBarText.Content = "İşlem Başarısız";
            }
           

        }

        private void myListsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedList = user.toDoLists.Where(p => p.name.Equals(myListsListView.SelectedItem.ToString())).FirstOrDefault(); 
            tasksOfList.ItemsSource = toDoListController.ListTasksofToDoList(selectedList);
            
        }

        private void NewTaskButton_Click(object sender, RoutedEventArgs e)
        {
            TaskWindow newTaskWindow = new TaskWindow(selectedList);
            newTaskWindow.Show();
        }

        private void removeListBtns_Click(object sender, RoutedEventArgs e)
        {
            toDoListController.Remove(selectedList);
            InitializeLeftMenu();

        }
    }
}
