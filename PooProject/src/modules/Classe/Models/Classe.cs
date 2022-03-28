using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooProject
{
    public class Classe
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Period { get; set; }
        public Discipline? Discipline { get; set; }
        public Professor? Professor { get; set; }
        public Schedule? Schedule { get; set; }
        public Grade? Grade { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }

        public Classe(string period, Schedule? schedule, Discipline? discipline, Professor? professor, Grade? grade)
        {
            if (!this.Id.Equals(Guid.Empty))
            {
                this.Id = Guid.NewGuid();
            }
            this.Period = period;
            this.Schedule = schedule;
            this.Discipline = discipline;
            this.Professor = professor;
            this.Grade = grade;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }

    }

}
