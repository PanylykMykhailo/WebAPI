using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Incidents
    {
        [Key]
        [MaxLength(450)]
        public string IncidentName { get; set;}
        public List<Accounts> Account { get; set; }
    }
}
