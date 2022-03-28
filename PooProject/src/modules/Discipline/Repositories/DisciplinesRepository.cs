using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooProject
{
    public class DisciplinesRepository
    {
        private DisciplinesRepository() { }
        static DisciplinesRepository obj = new DisciplinesRepository();
        public static DisciplinesRepository Singleton { get => obj; }
        private List<Discipline> repository = new List<Discipline>();

        public void Open()
        {
            File<List<Discipline>> f = new File<List<Discipline>>();
            repository = f.Open("../../Shared/Database/disciplines.xml");
        }

        public void Save()
        {
            File<List<Discipline>> f = new File<List<Discipline>>();
            f.Save("../../Shared/Database/disciplines.xml", ListAll());
        }

        public List<Discipline> ListAll()
        {
            repository.Sort();
            return repository;
        }

        public Discipline? ListOne(Guid id)
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

        public void Insert(string description, Professor? professor)
        {
            Discipline discipline = new Discipline(description, professor);
            repository.Add(discipline);
        }

        public void Update(Guid id, string? description, Professor? professor)
        {
            Discipline? discipline = ListOne(id);
            if (discipline == null)
            {
                Console.WriteLine("Discipline does not exist!");
                return;
            }
            if (description != null)
            {
                discipline.Description = description;
            }
            if (professor != null)
            {
                discipline.Professor = professor;
            }
        }

        public void Delete(Guid id)
        {
            Discipline? discipline = this.ListOne(id);
            if (discipline!= null)
            {
                repository.Remove(discipline);
            }
        }
    }
}
