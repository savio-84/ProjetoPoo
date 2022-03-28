using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooProject
{
    public class CoursesMatrixDisciplinesRepository
    {
        private CoursesMatrixDisciplinesRepository() { }
        static CoursesMatrixDisciplinesRepository obj = new CoursesMatrixDisciplinesRepository();
        public static CoursesMatrixDisciplinesRepository Singleton { get => obj; }
        private List<CourseMatrixDisciplines> repository = new List<CourseMatrixDisciplines>();

        public void Open()
        {
            File<List<CourseMatrixDisciplines>> f = new File<List<CourseMatrixDisciplines>>();
            repository = f.Open("../../Shared/Database/courses-matrix-disciplines.xml");
        }

        public void Save()
        {
            File<List<CourseMatrixDisciplines>> f = new File<List<CourseMatrixDisciplines>>();
            f.Save("../../Shared/Database/couses.xml", ListAll());
        }

        public List<CourseMatrixDisciplines> ListAll()
        {
            repository.Sort();
            return repository;
        }

        public CourseMatrixDisciplines? ListOne(Guid id)
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

        public void Insert(Schedule? schedule)
        {
            CourseMatrixDisciplines newCourse = new CourseMatrixDisciplines(schedule);
            repository.Add(newCourse);
        }

        public void Update(Guid id, Schedule? schedule)
        {
            CourseMatrixDisciplines? savedCourseMatrixDisciplines = ListOne(id);
            if (savedCourseMatrixDisciplines == null)
            {
                Console.WriteLine("Course does not exist!");
                return;
            }
            if (schedule!= null)
            {
                savedCourseMatrixDisciplines.Schedule = schedule;
            }
        }

        public void Delete(Guid id)
        {
            CourseMatrixDisciplines? courseMatrixDisciplines = this.ListOne(id);
            if (courseMatrixDisciplines != null)
            {
                repository.Remove(courseMatrixDisciplines);
            }
        }
    }
}
