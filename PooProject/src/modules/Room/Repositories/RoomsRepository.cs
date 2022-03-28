using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooProject
{
    public class RoomsRepository
    {
        private RoomsRepository() { }
        static RoomsRepository obj = new RoomsRepository();
        public static RoomsRepository Singleton { get => obj; }
        private List<Room> repository = new List<Room>();

        public void Open()
        {
            File<List<Room>> f = new File<List<Room>>();
            repository = f.Open("../../Shared/Database/rooms.xml");
        }

        public void Save()
        {
            File<List<Room>> f = new File<List<Room>>();
            f.Save("../../Shared/Database/rooms.xml", ListAll());
        }

        public List<Room> ListAll()
        {
            return repository;
        }

        public Room? ListOne(Guid id)
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

        public void Insert(string identification)
        {
            Room room = new Room(identification);
            repository.Add(room);
        }

        public void Update(Guid id, string? identification)
        {
            Room? room = ListOne(id);
            if (room == null)
            {
                Console.WriteLine("Course does not exist!");
                return;
            }
            if (identification!= null)
            {
                room.Identification = identification;
            }
        }

        public void Delete(Guid id)
        {
            Room? room = this.ListOne(id);
            if (room != null)
            {
                repository.Remove(room);
            }
        }
    }
}
