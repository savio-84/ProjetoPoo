using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooProject
{
    public class CoursesMatrixRepository
    {
        private CoursesMatrixRepository() { }
        static CoursesMatrixRepository obj = new CoursesMatrixRepository();
        public static CoursesMatrixRepository Singleton { get => obj; }
        private List<CourseMatrix> repository = new List<CourseMatrix>();

        public void Open()
        {
            File<List<CourseMatrix>> f = new File<List<CourseMatrix>>();
            repository = f.Open("../../Shared/Database/courses.xml");
        }

        public void Save()
        {
            File<List<CourseMatrix>> f = new File<List<CourseMatrix>>();
            f.Save("../../Shared/Database/courses-matrix.xml", ListAll());
        }

        public List<CourseMatrix> ListAll()
        {
            repository.Sort();
            return repository;
        }

        /*
         * public Guid Id { get; }
        public CourseMatrixDisciplines? CourseMatrixDisciplines;
        public Course? Course { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
        */

        public CourseMatrix? ListOne(Guid id)
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

        public void Insert(Course? course, CourseMatrixDisciplines? courseMatrixDisciplines)
        {
            CourseMatrix newCourseMatrix = new CourseMatrix(course, courseMatrixDisciplines);
            repository.Add(newCourseMatrix);
        }

        public void Update (Guid id, Course? course, CourseMatrixDisciplines? courseMatrixDisciplines)
        {
            CourseMatrix? courseMatrix = ListOne(id);

            if (courseMatrix == null)
            {
                Console.WriteLine("Course matrix does not exist!");
                return;
            }
            
            courseMatrix.Course = course;
            courseMatrix.CourseMatrixDisciplines = courseMatrixDisciplines;
        }

        public void Delete(Guid id)
        {
            CourseMatrix? courseMatrix = ListOne(id);

            if (courseMatrix != null)
            {
                repository.Remove(courseMatrix);
            }
        }        
    }
}
