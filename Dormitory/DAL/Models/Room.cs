using System;
using System.Collections.Generic;

namespace DormitoryApi.DAL.Models
{
    public partial class Room
    {
        public Room()
        {
            RoomStudents = new HashSet<RoomStudent>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Capacity { get; set; }
        public int DormitoryId { get; set; }

        public virtual Dormitory Dormitory { get; set; } = null!;
        public virtual ICollection<RoomStudent> RoomStudents { get; set; }
    }
}
