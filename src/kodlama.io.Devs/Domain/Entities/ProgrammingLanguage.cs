using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProgrammingLanguage:Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Technology > Technologies { get; set; }          

        public ProgrammingLanguage(int ıd, string name)
        {
            Id = ıd;
            Name = name;
        }

        public ProgrammingLanguage()
        {
        }
    }

}
