using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooProject
{
    public class ProfessorsRepository
    {
        private ProfessorsRepository() { }
        static ProfessorsRepository obj = new ProfessorsRepository();
        public static ProfessorsRepository Singleton { get => obj; }
        private List<Professor> repository = new List<Professor>();

        public void Open()
        {
            File<List<Professor>> f = new File<List<Professor>>();
            repository = f.Open("../../Shared/Database/professors.xml");
        }

        public void Save()
        {
            File<List<Professor>> f = new File<List<Professor>>();
            f.Save("../../Shared/Database/professors.xml", ListAll());
        }

        public List<Professor> ListAll()
        {
            return repository;
        }

        public Professor? ListOne(Guid id)
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

        // public Professor(string name, string email, string password)

        public void Insert(string name, string email, string password)
        {
            Professor professor = new Professor(name, email, password);
            repository.Add(professor);
        }

        public void Update(Guid id, string? name, string? email, string? password)
        {
            Professor? professor = ListOne(id);
            if (professor == null)
            {
                Console.WriteLine("Professor does not exist!");
                return;
            }
            if (name != null)
            {
                professor.Name = name;
            }

            if (email != null)
            {
                professor.Email = email;
            }

            if (password != null)
            {
                professor.Password = password;
            }
        }

        public void Delete(Guid id)
        {
            Professor? professor = this.ListOne(id);
            if (professor!= null)
            {
                repository.Remove(professor);
            }
        }
    }
}
