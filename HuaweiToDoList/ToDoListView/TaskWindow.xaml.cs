using Controller.Controllers;
using Data.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Task = Data.Model.Task;

namespace ToDoListView
{
    /// <summary>
    /// Interaction logic for TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        ToDoList selectedToDoList;
        TaskController taskController;
        public TaskWindow(ToDoList _selectedToDoList)
        {
            selectedToDoList = _selectedToDoList;
            taskController = new TaskController();
            InitializeComponent();
            newTaskBtn.Focus();
        }

    
        private void newTaskBtn_Click(object sender, RoutedEventArgs e)
        {
          
                Task task = new Task();
                task.name = taskNameTxt.Text;
                task.isExpired = false;
                task.description = taskDescriptionTxt.Text;
                task.list = selectedToDoList;
                task.createTime = DateTime.Now;
                if (taskDeadline.SelectedDate !=null)
                {
                    task.deadline = (DateTime)taskDeadline.SelectedDate;
                }
                else
                {
                    task.deadline = DateTime.Now;
                }
                
                task.isCompleted = false;
                taskController.Add(task);
                ListView v = (ListView)Application.Current.MainWindow.FindName("tasksOfList");
                v.ItemsSource = taskController.getTasksByListId(task.list.id);
                this.Close();
        

        }

        private void taskDeadline_SelectedDatesChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Mouse.Capture(null);
        }
    }
}
