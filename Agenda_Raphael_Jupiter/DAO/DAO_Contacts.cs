using System.Collections.Generic;
using System.Linq;
using Agenda_Raphael_Jupiter.DB;
using Agenda_Raphael_Jupiter.Model;
using Microsoft.EntityFrameworkCore;

namespace Agenda_Raphael_Jupiter.DAO
{
    public class DAO_Contacts
    {
        public void AddContact(Contact contact)
        {
            using (var context = new AgendaRaphaelContext())
            {
                context.Contacts.Add(contact);
                context.SaveChanges();
            }
        }

        public List<Contact> GetAllContacts()
        {
            using (var context = new AgendaRaphaelContext())
            {
                return context.Contacts.ToList();
            }
        }

        public void DeleteContact(int id)
        {
            using (var context = new AgendaRaphaelContext())
            {
                var contact = context.Contacts.Find(id);
                if (contact != null)
                {
                    context.Contacts.Remove(contact);
                    context.SaveChanges();
                }
            }
        }
    }
}