using Agenda_Raphael_Jupiter.DB;
using Agenda_Raphael_Jupiter.Model;
using System.Windows;

namespace Agenda_Raphael_Jupiter
{
    public partial class NewMemberWindow : Window
    {
        public Contact NewContact { get; private set; }

        public NewMemberWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NewContact = new Contact
            {
                Nom = NameTextBox.Text,
                Prenom = PrenomTextBox.Text,
                Email = EmailTextBox.Text,
                Telephone = PhoneTextBox.Text
            };
            DialogResult = true; // Indique que l'ajout est réussi
            Close();
        }
    }
}