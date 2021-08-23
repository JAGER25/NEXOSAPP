using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXOSAPI.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title{ get; set; }
        public int Year { get; set; }
        public string Gender { get; set; }
        public int NumberPages { get; set; }

        public int IdAuthor { get; set; }
        public Author Author { get; set; }
    }
}
