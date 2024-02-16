using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Domain.Entities;

namespace WebAppMVC.Application.League
{
    public class LeagueDto
    {
        [Required(ErrorMessage = "Enter the name of league, minimum 6 characters !!!")]
        [MinLength(6)]
        public string Name { get; set; }
        public string? TeamNames { get; set; } // separator -> ;
    }
}
