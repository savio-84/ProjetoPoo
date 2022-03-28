using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PooProject
{
    public class CourseMatrix
    {
        public Guid Id { get; } = Guid.NewGuid();
        public CourseMatrixDisciplines? CourseMatrixDisciplines { get; set; }
        public Course? Course { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }

        public CourseMatrix(Course? course, CourseMatrixDisciplines? courseMatrixDisciplines)
        {
            if (!this.Id.Equals(Guid.Empty))
            {
                this.Id = Guid.NewGuid();
            }
            this.Course = course;
            this.CourseMatrixDisciplines = courseMatrixDisciplines;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
    }

}