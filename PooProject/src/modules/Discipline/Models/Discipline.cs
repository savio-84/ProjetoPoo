using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooProject
{
    public class Discipline
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Description { get; set; }
        public Professor? Professor { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }

        public Discipline(string description, Professor? professor)
        {
            if (!this.Id.Equals(Guid.Empty))
            {
                this.Id = Guid.NewGuid();
            }
            this.Description = description;
            this.Professor = professor;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
    } 
}
