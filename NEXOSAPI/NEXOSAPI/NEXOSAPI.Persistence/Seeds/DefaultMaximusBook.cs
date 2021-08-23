using NEXOSAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXOSAPI.Persistence.Seeds
{
    public static class DefaultMaximusBook
    {
        public static List<MaximumBooks> MaximumBooksList()
        {
            return new List<MaximumBooks>()
            {
                new MaximumBooks
                {
                    Total = 1
                },
                new MaximumBooks
                {
                   Total = 5
                },
                 new MaximumBooks
                {
                   Total = 10
                },
                  new MaximumBooks
                {
                   Total = 15
                },
            };
        }
    }
}
