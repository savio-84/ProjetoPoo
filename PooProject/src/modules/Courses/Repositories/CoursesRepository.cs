using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooProject
{
    public class CoursesRepository
    {
        private CoursesRepository() { }
        static CoursesRepository obj = new CoursesRepository();
        public static CoursesRepository Singleton { get => obj; }

        private List<Course> repository = new List<Course>();

        public void Open()
        {
            File<List<Course>> f = new File<List<Course>>();
            repository = f.Open("../../Shared/Database/courses.xml");
        }

        public void Save()
        {
            File<List<Course>> f = new File<List<Course>>();
            f.Save("../../Shared/Database/couses.xml", ListAll());
        }

        public List<Course> ListAll()
        {   
            return repository;
        }

        public Course? ListOne(Guid id)
        {
            for (int i = 0; i < repository.Count; i++)
            {
                if (repository[i].Id == id)
                {
                    return repository[i];
                }
            }
            return null;
        }

        public void Insert(string description, CourseMatrix? courseMatrix)
        {
            Course newCourse = new Course(description, courseMatrix);
            repository.Add(newCourse);
        }

        public void Update(Guid id, string? description, CourseMatrix? courseMatrix)
        {
            Course? savedCourse = ListOne(id);
            if (savedCourse == null)
            {
                Console.WriteLine("Course does not exist!");
                return;
            }
            if (description != null)
            {
                savedCourse.Description = description;
            }
            savedCourse.CourseMatrix = courseMatrix;
        }

        public void Delete(Guid id)
        {
            Course? course = this.ListOne(id);
            if (course != null)
            {
                repository.Remove(course);
            }
        }
    }
}
