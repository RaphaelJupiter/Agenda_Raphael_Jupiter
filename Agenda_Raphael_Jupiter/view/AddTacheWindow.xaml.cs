using System;
using System.Windows;

namespace Agenda_Raphael_Jupiter
{
    public partial class AddTacheWindow : Window
    {
        public string TaskText { get; private set; }
        public DateTime? DueDate { get; private set; }

        public AddTacheWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            TaskText = taskTextBox.Text;
            DueDate = dueDatePicker.SelectedDate;

            if (string.IsNullOrWhiteSpace(TaskText))
            {
                MessageBox.Show("Veuillez entrer une tâche.");
                return;
            }

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
