using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooProject
{
    public class StudentsRepository
    {
        private StudentsRepository() { }
        static StudentsRepository obj = new StudentsRepository();
        public static StudentsRepository Singleton { get => obj; }
        private List<Student> repository = new List<Student>();

        public void Open()
        {
            File<List<Student>> f = new File<List<Student>>();
            repository = f.Open("./students.xml");
        }

        public void Save()
        {
            File<List<Student>> f = new File<List<Student>>();
            f.Save("./students.xml", ListAll());
        }

        public List<Student> ListAll()
        {
            return repository;
        }


        public Student? ListOne(Guid id)
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

        public void Insert(string name, string email, string password, string enrolment, Course? course, Grade? grade)
        {
            Student student = new Student(name, email, password, enrolment, course, grade);
            repository.Add(student);
        }

        public void Update(Guid id, string? name, string? email, string? password, string? enrolment, Course? course, Grade? grade)
        {
            Student? student = ListOne(id);
            if (student == null)
            {
                Console.WriteLine("Student does not exist!");
                return;
            }

            if (name != null)
            {
                student.Name = name;
            }

            if (email != null)
            {
                student.Email = email;
            }

            if (password != null)
            {
                student.Password = password;
            }

            if (enrolment != null)
            {
                student.Enrolment = enrolment;
            }

            if (course != null)
            {
                student.Course = course;
            }

            if (grade != null)
            {
                student.Grade = grade;
            }
        }

        public void Delete(Guid id)
        {
            Student? student = this.ListOne(id);
            if (student != null)
            {
                repository.Remove(student);
            }
        }

        public void GetByCourse(Course course)
        {
            List<Student> students = repository.Where(x => x.Course == course).OrderBy(x => x.Enrolment).ToList();
            int total = repository.Where(x => x.Course == course).Count();
            foreach (Student student in students)
            {
                Console.WriteLine("Id: "+student.Id);
                Console.WriteLine("Nome: "+student.Name);
                Console.WriteLine("-----------------------------");
            }
            Console.WriteLine("Total: "+total);
        }

        public void ListFirst3()
        {
            List<Student> students = repository.OrderBy(x => x.Enrolment).Take(3).ToList();
            foreach (Student student in students)
            {
                Console.WriteLine("Id: " + student.Id);
                Console.WriteLine("Nome: " + student.Name);
                Console.WriteLine("-----------------------------");
            }
        }

        public void GetNamesList()
        {
            List<string> students = repository.OrderBy(x => x.Enrolment).Select(x => x.Name).ToList();
            foreach(string name in students)
            {
                Console.WriteLine(name);
            }
        }

        public void GetFirst()
        {
            Student student = repository.FirstOrDefault();
            Console.WriteLine(student.Id + " - " + student.Name);
        }
    }
}