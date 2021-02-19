using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Contacts
    {
        [Key]
        [MaxLength(50)]
        public string Email { get; set;}
        public string FirstName { get; set;}
        public string LastName { get; set;}
        [JsonIgnore]
        public Accounts Account { get; set; }
        //[JsonIgnore]
        public string Username { get; set; }
    }
}
