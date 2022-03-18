using System;
using UniClub.Services.Interfaces;

namespace UniClub.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow.AddHours(7);
    }
}
