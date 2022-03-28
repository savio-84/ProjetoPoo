using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooProject
{
    public class CourseMatrixDisciplines
    {
        public Guid Id { get; } = Guid.NewGuid();
        public Schedule? Schedule {get; set;}
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }

        public CourseMatrixDisciplines(Schedule? schedule)
        {
            if (!this.Id.Equals(Guid.Empty))
            {
                this.Id = Guid.NewGuid();
            }
            this.Schedule = schedule;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
    } 

}
