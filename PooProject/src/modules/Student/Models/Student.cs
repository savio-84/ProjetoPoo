using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooProject
{
    public class Student: Person
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Enrolment { get; set; }
        public Course? Course { get; set; }
        public Grade? Grade { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }

        public Student(string name, string email, string password, string enrolment, Course? course, Grade? grade)
        {
            if (!this.Id.Equals(Guid.Empty))
            {
                this.Id = Guid.NewGuid();
            }
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.Enrolment = enrolment;
            this.Course = course;
            this.Grade = grade;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
    }
}
