using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooProject
{

    public  class Schedule
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime ScheduleStart { get; set; }
        public DateTime ScheduleEnd { get; set; }
        public CourseMatrixDisciplines? CourseMatrixDisciplines { get; set; }
        public Room? Room { get; set; }
        public Classe? Classe { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }

        public Schedule(DateTime scheduleStart, DateTime scheduleEnd, CourseMatrixDisciplines? courseMatrixDisciplines, Room room, Classe? classe)
        {
            if (!this.Id.Equals(Guid.Empty))
            {
                this.Id = Guid.NewGuid();
            }
            this.ScheduleStart = scheduleStart;
            this.ScheduleEnd = scheduleEnd;
            this.Room = room;
            this.CourseMatrixDisciplines = courseMatrixDisciplines;
            this.Classe = classe;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;

        }

    }

}
