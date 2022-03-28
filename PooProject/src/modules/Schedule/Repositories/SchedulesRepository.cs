using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooProject
{
    public class SchedulesRepository
    {
        private SchedulesRepository() { }
        static SchedulesRepository obj = new SchedulesRepository();
        public static SchedulesRepository Singleton { get => obj; }
        private List<Schedule> repository = new List<Schedule>();

        public void Open()
        {
            File<List<Schedule>> f = new File<List<Schedule>>();
            repository = f.Open("../../Shared/Database/schedules.xml");
        }

        public void Save()
        {
            File<List<Schedule>> f = new File<List<Schedule>>();
            f.Save("../../Shared/Database/couses.xml", ListAll());
        }

        public List<Schedule> ListAll()
        {
            return repository;
        }

        public Schedule? ListOne(Guid id)
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

        
        public void Insert(DateTime scheduleStart, DateTime scheduleEnd, CourseMatrixDisciplines? courseMatrixDisciplines, Room room, Classe? classe)
        {
            Schedule newSchedule = new Schedule(scheduleStart, scheduleEnd, courseMatrixDisciplines, room, classe);
            repository.Add(newSchedule);
        }

        public void Update(Guid id, DateTime scheduleStart, DateTime scheduleEnd, CourseMatrixDisciplines? courseMatrixDisciplines, Room? room, Classe? classe)
        {
            Schedule? schedule = ListOne(id);
            if (schedule == null)
            {
                Console.WriteLine("Course does not exist!");
                return;
            }
            schedule.ScheduleStart = scheduleStart;
            schedule.ScheduleEnd = scheduleEnd;

            if (courseMatrixDisciplines != null)
            {
                schedule.CourseMatrixDisciplines = courseMatrixDisciplines;
            }

            if (room != null)
            {
                schedule.Room = room;
            }

            if (classe != null)
            {
                schedule.Classe = classe;
            }
        }

        public void Delete(Guid id)
        {
            Schedule? schedule = this.ListOne(id);
            if (schedule!= null)
            {
                repository.Remove(schedule);
            }
        }

    }
}
