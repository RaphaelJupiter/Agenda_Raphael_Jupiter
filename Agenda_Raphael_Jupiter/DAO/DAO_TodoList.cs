using Agenda_Raphael_Jupiter.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda_Raphael_Jupiter.DAO
{
    internal class DAO_todolist
    {
        // Ajouter une tâche
        public void AddTask(TodoList task)
        {
            using var context = new AgendaRaphaelContext();
            context.TodoLists.Add(task);
            context.SaveChanges();
        }

        // Récupérer toutes les tâches
        public List<TodoList> GetAllTasks()
        {
            using var context = new AgendaRaphaelContext();
            return context.TodoLists.ToList();
        }

        // Supprimer une tâche par ID
        public void DeleteTask(int taskId)
        {
            using var context = new AgendaRaphaelContext();
            var task = context.TodoLists.Find(taskId);
            if (task != null)
            {
                context.TodoLists.Remove(task);
                context.SaveChanges();
            }
        }

        // (Optionnel) Mettre à jour le statut d'une tâche
        public void UpdateTaskStatus(int taskId, string newStatus)
        {
            using var context = new AgendaRaphaelContext();
            var task = context.TodoLists.Find(taskId);
            if (task != null)
            {
                task.Statut = newStatus;
                context.SaveChanges();
            }
        }
    }
}
