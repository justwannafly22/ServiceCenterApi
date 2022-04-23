using System;

namespace ClientApi.Domain
{
    public class ClientDomainModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public bool AllowEmailNotification { get; set; }
    }
}
