using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Agenda_Raphael_Jupiter.DAO;
using Agenda_Raphael_Jupiter.DB;
using Agenda_Raphael_Jupiter.Model;

namespace Agenda_Raphael_Jupiter
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Member> members = new();
        private ObservableCollection<Contact> contacts = new();
        private DAO_Contacts daoContacts = new();

        public MainWindow()
        {
            InitializeComponent();
            LoadContacts();
            membersDataGrid.ItemsSource = members;
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = textBoxFilter.Text.Trim().ToLower();
            var contacts = daoContacts.GetAllContacts();

            var filteredContacts = contacts.Where(c =>
                c.Nom.ToLower().Contains(searchText) ||
                (!string.IsNullOrEmpty(c.Prenom) && c.Prenom.ToLower().Contains(searchText)) ||
                (!string.IsNullOrEmpty(c.Email) && c.Email.ToLower().Contains(searchText)) ||
                (!string.IsNullOrEmpty(c.Telephone) && c.Telephone.Contains(searchText))
            ).ToList();

            // Conversion en Member
            var members = filteredContacts.Select((contact, index) => new Member
            {
                Number = (index + 1).ToString(),
                Character = contact.Nom.Substring(0, 1).ToUpper(),
                BgColor = new SolidColorBrush(Colors.Purple), // tu peux utiliser ta logique de couleur ici
                Name = contact.Nom,
                Prenom = contact.Prenom,
                Email = contact.Email,
                Phone = contact.Telephone
            }).ToList();

            membersDataGrid.ItemsSource = members;

        }

        // Charger les contacts depuis la BDD et les convertir en Members pour l'affichage
        private void LoadContacts()
        {
            contacts = new ObservableCollection<Contact>(daoContacts.GetAllContacts());
            members.Clear();
            membersDataGrid.ItemsSource = contacts;


            foreach (var contact in contacts)
            {
                members.Add(ConvertToMember(contact));
            }
        }

        // Convertit un Contact (BDD) en Member (affichage)
        private Member ConvertToMember(Contact contact)
        {
            return new Member
            {
                Name = contact.Nom,
                Prenom = contact.Prenom,
                Phone = contact.Telephone,
                Email = contact.Email,
                Character = contact.Nom?.FirstOrDefault().ToString().ToUpper() ?? "?",
                BgColor = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.MediumPurple) // Couleur personnalisable
            };
        }

        // Double clic pour maximiser/réduire
        private bool IsMaximize = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                this.WindowState = IsMaximize ? WindowState.Normal : WindowState.Maximized;
                IsMaximize = !IsMaximize;
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        // Ajouter un contact
        private void AddContactButton_Click(object sender, RoutedEventArgs e)
        {
            NewMemberWindow newMemberWindow = new NewMemberWindow();
            if (newMemberWindow.ShowDialog() == true)
            {
                var newContact = newMemberWindow.NewContact;
                daoContacts.AddContact(newContact); // Ajout en base
                contacts.Add(newContact); // Ajout dans la liste locale
                members.Add(ConvertToMember(newContact)); // Ajout dans la vue
            }
        }

        // Supprimer un contact
        private void DeleteContactButton_Click(object sender, RoutedEventArgs e)
        {
            if (membersDataGrid.SelectedItem is Member selectedMember)
            {
                // Retrouve le contact associé via Nom + Prénom
                var contactToDelete = contacts.FirstOrDefault(c =>
                    c.Nom == selectedMember.Name && c.Prenom == selectedMember.Prenom);

                if (contactToDelete != null)
                {
                    daoContacts.DeleteContact(contactToDelete); // Supprimer de la BDD
                    contacts.Remove(contactToDelete); // Supprimer de la liste des contacts
                    members.Remove(selectedMember); // Supprimer de la vue
                    MessageBox.Show($"Contact {contactToDelete.Nom} supprimé avec succès.");
                }
                else
                {
                    MessageBox.Show("Contact non trouvé dans la base de données.");
                }
            }
            else
            {
                MessageBox.Show("Aucun membre sélectionné.");
            }
        }

        private void CalendrierButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TodoListButton_Click(object sender, RoutedEventArgs e)
        {
            ToDoListPage todoWindow = new ToDoListPage();
            todoWindow.Show();
            this.Close(); 
        }



    }
}
