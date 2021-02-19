using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
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
    public class Accounts
    {
        [Key]
        [MaxLength(100)]
        public string Username { get; set; }
        public List<Contacts> Contact { get; set; }
        //[/*JsonIgnore]*/
        public string Incidents { get; set; }
        [JsonIgnore]
        public Incidents Incident { get; set; }
    }
}
