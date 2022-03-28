using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PooProject
{
    public class Course
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Description { get; set; }
        public CourseMatrix? CourseMatrix { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }

        public Course(string description, CourseMatrix? courseMatrix)
        {
            if (!this.Id.Equals(Guid.Empty))
            {
                this.Id = Guid.NewGuid();
            }
            if (courseMatrix != null)
            {
                this.CourseMatrix = courseMatrix;
            }
            this.Description = description;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
    }
}
