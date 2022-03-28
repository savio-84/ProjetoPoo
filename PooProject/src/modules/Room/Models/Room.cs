using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PooProject
{
    public class Room
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Identification { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }

        public Room(string identification)
        {
            if (!this.Id.Equals(Guid.Empty))
            {
                this.Id = Guid.NewGuid();
            }
            this.Identification = identification;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
    }
}