﻿using EntityFramework;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    /// <summary>
    /// ClientService
    /// </summary>
    public class ClientService
    {
        private readonly DatabaseContext databaseContext;

        public ClientService()
        {
            databaseContext = new DatabaseContext();
        }

        public void CreateClient(Client client)
        {
            databaseContext.Clients.Add(client);
            databaseContext.SaveChanges();
        }

        public void EditClient(Client client)
        {
            databaseContext.SaveChanges();
        }

        public void RemoveClient(int id)
        {
            var client = databaseContext.Clients.FirstOrDefault(x => x.Id == id);
            databaseContext.Clients.Remove(client);
            databaseContext.SaveChanges();
        }

        public List<Client> GetAll()
        {
            return databaseContext.Clients.ToList();
        }

        public Client GetById(int id)
        {
            return databaseContext.Clients.FirstOrDefault(x =>x.Id == id);
        }
    }
}
