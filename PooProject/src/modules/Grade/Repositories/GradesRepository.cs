using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooProject
{
    public class GradesRepository
    {
        private GradesRepository() { }
        static GradesRepository obj = new GradesRepository();
        public static GradesRepository Singleton { get => obj; }
        private List<Grade> repository = new List<Grade>();

        public void Open()
        {
            File<List<Grade>> f = new File<List<Grade>>();
            repository = f.Open("../../Shared/Database/grades.xml");
        }

        public void Save()
        {
            File<List<Grade>> f = new File<List<Grade>>();
            f.Save("../../Shared/Database/grades.xml", ListAll());
        }

        public List<Grade> ListAll()
        {
            repository.Sort();
            return repository;
        }

        public Grade? ListOne(Guid id)
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

        // public Grade(Classe? classe, Student? student)

        public void Insert(Classe? classe, Student? student)
        {
            Grade grade = new Grade(classe, student);
            repository.Add(grade);
        }

        public void Update(Guid id, Classe? classe, Student? student)
        {
            Grade? grade = ListOne(id);
            if (grade == null)
            {
                Console.WriteLine("Grade does not exist!");
                return;
            }
            if (classe != null)
            {
                grade.Classe = classe;
            }

            if (student != null)
            {
                grade.Student = student;
            }
        }

        public void Delete(Guid id)
        {
            Grade? grade = this.ListOne(id);
            if (grade != null)
            {
                repository.Remove(grade);
            }
        }
    }
}
