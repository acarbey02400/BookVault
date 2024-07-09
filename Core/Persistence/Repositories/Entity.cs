using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public class Entity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public int? CreatedById { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public User? CreatedBy { get; set; }
        public User? UpdatedBy { get; set; }
        public Entity()
        {
        }

        public Entity(int id) : this()
        {
            Id = id;
        }
    }
}
