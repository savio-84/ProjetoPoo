using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooProject
{
    public class ClassesRepository
    {
        private ClassesRepository() { }
        static ClassesRepository obj = new ClassesRepository();
        public static ClassesRepository Singleton { get => obj; }
        private List<Classe> repository = new List<Classe>();

        public void Open()
        {
            File<List<Classe>> f = new File<List<Classe>>();
            repository = f.Open("../../Shared/Database/classes.xml");
        }

        public void Save()
        {
            File<List<Classe>> f = new File<List<Classe>>();
            f.Save("../../Shared/Database/couses.xml", ListAll());
        }

        public List<Classe> ListAll()
        {
            repository.Sort();
            return repository;
        }

        public Classe? ListOne(Guid id)
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

        public void Insert(string period, Schedule? schedule, Discipline? discipline, Professor? professor, Grade? grade)
        {
            Classe classe = new Classe(period, schedule, discipline, professor, grade);
            repository.Add(classe);
        }

        public void Update(Guid id, string period, Schedule? schedule, Discipline? discipline, Professor? professor, Grade? grade)
        {
            Classe? classe = ListOne(id);
            if (classe == null)
            {
                Console.WriteLine("Classe does not exist!");
                return;
            }
            if (schedule!= null)
            {
                classe.Schedule = schedule;
            }
            
            if (discipline != null)
            {
                classe.Discipline = discipline;
            }

            if (professor != null)
            {
                classe.Professor = professor;
            }

            if (grade != null)
            {
                classe.Grade = grade;
            }
        }

        public void Delete(Guid id)
        {
            Classe? room = this.ListOne(id);
            if (room != null)
            {
                repository.Remove(room);
            }
        }
    }
}
