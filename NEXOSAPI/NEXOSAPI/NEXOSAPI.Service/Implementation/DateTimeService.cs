using NEXOSAPI.Service.Contract;
using System;

namespace NEXOSAPI.Service.Implementation
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}