using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooProject
{
    public class Grade
    {
        public Guid Id { get; } = Guid.NewGuid();
        public Classe? Classe { get; set; }
        public Student? Student { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }

        public Grade(Classe? classe, Student? student)
        {
            if (!this.Id.Equals(Guid.Empty))
            {
                this.Id = Guid.NewGuid();
            }
            this.Classe = classe;
            this.Student = student;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
    }
}