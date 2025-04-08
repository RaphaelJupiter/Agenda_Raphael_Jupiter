﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Agenda_Raphael_Jupiter.DAO;
using Agenda_Raphael_Jupiter.DB;
using Agenda_Raphael_Jupiter.Model;


namespace Agenda_Raphael_Jupiter 
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Contact> contacts;
        private DAO_Contacts daoContacts;

        public MainWindow()
        {
            InitializeComponent();
            daoContacts = new DAO_Contacts();
            LoadContacts();

            var converter = new BrushConverter();
            ObservableCollection<Member> members = new ObservableCollection<Member>();

            members.Add(new Member { Number = "1", Character = "J", BgColor = (Brush)converter.ConvertFromString("#1098AD"), Name = "John Doe", Prenom = "Coach", Email = "john.doe@gmail.com", Phone = "415-954-1475" });
            members.Add(new Member { Number = "2", Character = "R", BgColor = (Brush)converter.ConvertFromString("#1E88E5"), Name = "Reza Alavi", Prenom = "Administrator", Email = "reza110@hotmail.com", Phone = "254-451-7893" });
            members.Add(new Member { Number = "3", Character = "D", BgColor = (Brush)converter.ConvertFromString("#FF8F00"), Name = "Dennis Castillo", Prenom = "Coach", Email = "deny.cast@gmail.com", Phone = "125-520-0141" });
            members.Add(new Member { Number = "4", Character = "G", BgColor = (Brush)converter.ConvertFromString("#FF5252"), Name = "Gabriel Cox", Prenom = "Coach", Email = "coxcox@gmail.com", Phone = "808-635-1221" });
            members.Add(new Member { Number = "5", Character = "L", BgColor = (Brush)converter.ConvertFromString("#0CA678"), Name = "Lena Jones", Prenom = "Manager", Email = "lena.offi@hotmail.com", Phone = "320-658-9174" });
            members.Add(new Member { Number = "6", Character = "B", BgColor = (Brush)converter.ConvertFromString("#6741D9"), Name = "Benjamin Caliword", Prenom = "Administrator", Email = "beni12@hotmail.com", Phone = "114-203-6258" });
            members.Add(new Member { Number = "7", Character = "S", BgColor = (Brush)converter.ConvertFromString("#FF6D00"), Name = "Sophia Muris", Prenom = "Coach", Email = "sophi.muri@gmail.com", Phone = "852-233-6854" });
            members.Add(new Member { Number = "8", Character = "A", BgColor = (Brush)converter.ConvertFromString("#FF5252"), Name = "Ali Pormand", Prenom = "Manager", Email = "alipor@yahoo.com", Phone = "968-378-4849" });
            members.Add(new Member { Number = "9", Character = "F", BgColor = (Brush)converter.ConvertFromString("#1E88E5"), Name = "Frank Underwood", Prenom = "Manager", Email = "frank@yahoo.com", Phone = "301-584-6966" });
            members.Add(new Member { Number = "10", Character = "S", BgColor = (Brush)converter.ConvertFromString("#0CA678"), Name = "Saeed Dasman", Prenom = "Coach", Email = "saeed.dasi@hotmail.com", Phone = "817-320-5052" });

            members.Add(new Member { Number = "11", Character = "J", BgColor = (Brush)converter.ConvertFromString("#1098AD"), Name = "John Doe", Prenom = "Coach", Email = "john.doe@gmail.com", Phone = "415-954-1475" });
            members.Add(new Member { Number = "12", Character = "R", BgColor = (Brush)converter.ConvertFromString("#1E88E5"), Name = "Reza Alavi", Prenom = "Administrator", Email = "reza110@hotmail.com", Phone = "254-451-7893" });
            members.Add(new Member { Number = "13", Character = "D", BgColor = (Brush)converter.ConvertFromString("#FF8F00"), Name = "Dennis Castillo", Prenom = "Coach", Email = "deny.cast@gmail.com", Phone = "125-520-0141" });
            members.Add(new Member { Number = "14", Character = "G", BgColor = (Brush)converter.ConvertFromString("#FF5252"), Name = "Gabriel Cox", Prenom = "Coach", Email = "coxcox@gmail.com", Phone = "808-635-1221" });
            members.Add(new Member { Number = "15", Character = "L", BgColor = (Brush)converter.ConvertFromString("#0CA678"), Name = "Lena Jones", Prenom = "Manager", Email = "lena.offi@hotmail.com", Phone = "320-658-9174" });
            members.Add(new Member { Number = "16", Character = "B", BgColor = (Brush)converter.ConvertFromString("#6741D9"), Name = "Benjamin Caliword", Prenom = "Administrator", Email = "beni12@hotmail.com", Phone = "114-203-6258" });
            members.Add(new Member { Number = "17", Character = "S", BgColor = (Brush)converter.ConvertFromString("#FF6D00"), Name = "Sophia Muris", Prenom = "Coach", Email = "sophi.muri@gmail.com", Phone = "852-233-6854" });
            members.Add(new Member { Number = "18", Character = "A", BgColor = (Brush)converter.ConvertFromString("#FF5252"), Name = "Ali Pormand", Prenom = "Manager", Email = "alipor@yahoo.com", Phone = "968-378-4849" });
            members.Add(new Member { Number = "19", Character = "F", BgColor = (Brush)converter.ConvertFromString("#1E88E5"), Name = "Frank Underwood", Prenom = "Manager", Email = "frank@yahoo.com", Phone = "301-584-6966" });
            members.Add(new Member { Number = "20", Character = "S", BgColor = (Brush)converter.ConvertFromString("#0CA678"), Name = "Saeed Dasman", Prenom = "Coach", Email = "saeed.dasi@hotmail.com", Phone = "817-320-5052" });

            members.Add(new Member { Number = "21", Character = "J", BgColor = (Brush)converter.ConvertFromString("#1098AD"), Name = "John Doe", Prenom = "Coach", Email = "john.doe@gmail.com", Phone = "415-954-1475" });
            members.Add(new Member { Number = "22", Character = "R", BgColor = (Brush)converter.ConvertFromString("#1E88E5"), Name = "Reza Alavi", Prenom = "Administrator", Email = "reza110@hotmail.com", Phone = "254-451-7893" });
            members.Add(new Member { Number = "23", Character = "D", BgColor = (Brush)converter.ConvertFromString("#FF8F00"), Name = "Dennis Castillo", Prenom = "Coach", Email = "deny.cast@gmail.com", Phone = "125-520-0141" });
            members.Add(new Member { Number = "24", Character = "G", BgColor = (Brush)converter.ConvertFromString("#FF5252"), Name = "Gabriel Cox", Prenom = "Coach", Email = "coxcox@gmail.com", Phone = "808-635-1221" });
            members.Add(new Member { Number = "25", Character = "L", BgColor = (Brush)converter.ConvertFromString("#0CA678"), Name = "Lena Jones", Prenom = "Manager", Email = "lena.offi@hotmail.com", Phone = "320-658-9174" });
            members.Add(new Member { Number = "26", Character = "B", BgColor = (Brush)converter.ConvertFromString("#6741D9"), Name = "Benjamin Caliword", Prenom = "Administrator", Email = "beni12@hotmail.com", Phone = "114-203-6258" });
            members.Add(new Member { Number = "27", Character = "S", BgColor = (Brush)converter.ConvertFromString("#FF6D00"), Name = "Sophia Muris", Prenom = "Coach", Email = "sophi.muri@gmail.com", Phone = "852-233-6854" });
            members.Add(new Member { Number = "28", Character = "A", BgColor = (Brush)converter.ConvertFromString("#FF5252"), Name = "Ali Pormand", Prenom = "Manager", Email = "alipor@yahoo.com", Phone = "968-378-4849" });
            members.Add(new Member { Number = "29", Character = "F", BgColor = (Brush)converter.ConvertFromString("#1E88E5"), Name = "Frank Underwood", Prenom = "Manager", Email = "frank@yahoo.com", Phone = "301-584-6966" });
            members.Add(new Member { Number = "30", Character = "S", BgColor = (Brush)converter.ConvertFromString("#0CA678"), Name = "Saeed Dasman", Prenom = "Coach", Email = "saeed.dasi@hotmail.com", Phone = "817-320-5052" });

            membersDataGrid.ItemsSource = members;
        }

        private void LoadContacts()
        {
            contacts = new ObservableCollection<Contact>(daoContacts.GetAllContacts());
            membersDataGrid.ItemsSource = contacts;
        }




        private bool IsMaximize = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximize)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximize = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximize = true;
                }
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void AddContactButton_Click(object sender, RoutedEventArgs e)
        {
            NewMemberWindow newMemberWindow = new NewMemberWindow();
            if (newMemberWindow.ShowDialog() == true)
            {
                var newContact = newMemberWindow.NewContact;
                contacts.Add(newContact); // Ajoute le nouveau contact à la liste
                daoContacts.AddContact(newContact); // Ajoute à la base de données si nécessaire
            }
        }
        private void DeleteContactButton_Click(object sender, RoutedEventArgs e)
        {
            if (membersDataGrid.SelectedItem is Contact selectedContact)
            {
                contacts.Remove(selectedContact); // Retire le contact de la liste
                daoContacts.DeleteContact(selectedContact); // Supprime de la base de données
            }
        }


    }
}

