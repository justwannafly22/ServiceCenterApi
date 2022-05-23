using System;

namespace MasterApi.Domain
{
    public class MasterDomainModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public Guid AttendeeId { get; set; }
    }
}
