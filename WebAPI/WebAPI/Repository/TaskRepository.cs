using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _dbContext;
        public TaskRepository(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Incidents>> GetIncident()
        {
            var info = await _dbContext.Incident.ToListAsync();
            return info;
        }
        public async Task<IEnumerable<Contacts>> GetContact(string email)
        {
            var info = await _dbContext.Contact.Where(c => c.Email == email).ToListAsync();
            return info;
        }
        public async Task<IEnumerable<Accounts>> GetAccount(string id)
        {
            var info = await _dbContext.Account.Where(username => username.Username == id).ToListAsync();
            return info;
        }
        public int CreateIncident(Incidents incident)
        {
            int some = 0;
            foreach (var a in incident.Account) 
            {
                var result = _dbContext.Account.Find(a.Username);
                foreach (var c in a.Contact) 
                {
                    var contactresult = _dbContext.Contact.Find(c.Email);
                    if (result != null && contactresult != null)
                    {
                       
                        result.Incidents = incident.IncidentName;

                        _dbContext.Account.Update(result);
                        
                        incident.Account = new List<Accounts> { };
                        if (_dbContext.Incident.Find(incident.IncidentName) != null)
                        {
                            _dbContext.SaveChanges();
                            some++;
                        }
                        else 
                        {
                            _dbContext.Incident.Add(incident);
                            _dbContext.SaveChanges();
                            some++;
                        }    
                    }
                    else 
                    {
                        break;
                    }
                }
            }
            return some;
        }
        public void UpdateAccount( Accounts account) 
        {
            Contacts contact = new Contacts();
            var result = _dbContext.Account.Where(username => username.Username == account.Username).ToList();
            foreach (var a in account.Contact)
            {
                var resultcontact = _dbContext.Contact.Where(email => email.Email == a.Email).ToList();
                if (result == null && resultcontact == null)
                {
                    break;
                }
                else 
                {
                    contact.Email = a.Email;
                    contact.FirstName = a.FirstName;
                    contact.LastName = a.LastName;
                    contact.Username = a.Username;
                    _dbContext.Contact.Update(contact);
                    _dbContext.SaveChanges();
                }
            }
        }
        public void CreateAccount(Accounts account) 
        {
            Contacts contacts = new Contacts();
            foreach (var c in account.Contact)
            {
                contacts.FirstName = c.FirstName;
                contacts.LastName = c.LastName;
                contacts.Email = c.Email;
                contacts.Username = account.Username;
            }
            _dbContext.Contact.Add(contacts);
            account.Contact = new List<Contacts> {};
            _dbContext.Account.Add(account);
            _dbContext.SaveChanges();
            
           
        }
        public void CreateContact(Contacts contact) 
        {
            var result = _dbContext.Account.Find(contact.Username);
            if (result != null)
            {
                _dbContext.Contact.Add(contact);
                _dbContext.SaveChanges();
            }
            else 
            {
                Accounts account = new Accounts();
                account.Username = contact.Username;
                account.Contact = new List<Contacts> {contact};
                CreateAccount(account);  
            } 
           
           
        }
    }
}
