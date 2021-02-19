using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public interface ITaskRepository
    {
        public Task<IEnumerable<Incidents>> GetIncident();
        public Task<IEnumerable<Contacts>> GetContact(string email);
        public Task<IEnumerable<Accounts>> GetAccount(string id);
        public void UpdateAccount(Accounts account);    
        public int CreateIncident(Incidents incident);
        public void CreateAccount(Accounts account);
        public void CreateContact(Contacts contact);

    }
}
