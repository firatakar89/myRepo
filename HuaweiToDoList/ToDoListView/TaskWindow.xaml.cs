using Controller.Controllers;
using Data.Model;
using System;
using System.Windows;
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
        }

    
        private void newTaskBtn_Click(object sender, RoutedEventArgs e)
        {
            try
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
                this.Close();
            }
            catch(Exception ex) {
                TransactionStatusBarText.Content = "İşlem Başarısız";
            }

        }
    }
}
