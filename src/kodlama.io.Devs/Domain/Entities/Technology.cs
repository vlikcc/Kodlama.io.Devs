using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Technology:Entity
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public  string Name { get; set; }
        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }
        

        public Technology(int ıd, int programmingLanguageId, string name)
        {
            Id = ıd;
            ProgrammingLanguageId = programmingLanguageId;
            Name = name;
        }

        public Technology()
        {
        }
    }
}
