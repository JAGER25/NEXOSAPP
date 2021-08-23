using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXOSAPI.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string FullName { get; set; }
        public DateTime DateBirth { get; set; }
        public string CityOrigin { get; set; }


        public int IdMaximumBooks { get; set; }
        public MaximumBooks MaximumBooks { get; set; }
    }
}
