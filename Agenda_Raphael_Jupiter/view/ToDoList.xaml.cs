using Agenda_Raphael_Jupiter.DAO;
using Agenda_Raphael_Jupiter.DB;
using Agenda_Raphael_Jupiter.view;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Agenda_Raphael_Jupiter
{
    public partial class ToDoListPage : Window
    {
        private readonly DAO_todolist daoTodolist = new DAO_todolist();

        public ToDoListPage()
        {
            InitializeComponent();
            LoadTasks();
        }

        // Chargement des tâches au démarrage
        private void LoadTasks()
        {
            var tasks = daoTodolist.GetAllTasks();
            tasksDataGrid.ItemsSource = tasks;
        }

        // Ajout d'une tâche
        private void AddToDoButton_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddTacheWindow(); // Fait le lien avec la nouvelle fenêtre
            if (addWindow.ShowDialog() == true)
            {
                var newTask = new TodoList
                {
                    Tache = addWindow.TaskText,
                    DateLimite = addWindow.DueDate,
                    Statut = "En cours",
                    UtilisateurId = 1 // Adapter si multi-utilisateur
                };

                daoTodolist.AddTask(newTask);
                LoadTasks();
            }
        }

        // Suppression d'une tâche
        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var task = button?.DataContext as TodoList;

            if (task != null)
            {
                var result = MessageBox.Show("Supprimer cette tâche ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    daoTodolist.DeleteTask(task.IdtodoList);
                    LoadTasks();
                }
            }
        }

        // (Optionnel) Recherche par tâche
        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = textBoxSearch.Text.Trim().ToLower();
            var tasks = daoTodolist.GetAllTasks();

            var filtered = tasks.FindAll(t =>
                t.Tache.ToLower().Contains(search) ||
                (t.Statut != null && t.Statut.ToLower().Contains(search)));

            tasksDataGrid.ItemsSource = filtered;
        }

        // Pour pouvoir déplacer la fenêtre
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void ContactsButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(); 
            mainWindow.Show();                       
            this.Close();                            
        }
    }
}
