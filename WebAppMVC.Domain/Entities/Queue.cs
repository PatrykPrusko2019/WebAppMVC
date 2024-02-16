using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMVC.Domain.Entities
{
    public class Queue
    {
        public int Id { get; set; }
        
        public string Description { get; set; } // First
        public bool Finish { get; set; } = false;

        public virtual List<Match> Matches { get; set; } = new List<Match>();

    }
}
