using ClientApi.Domain;
using ClientApi.Repository.Entities;
using System;

namespace ClientApi.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public Client ToClient(ClientDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new Client
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Age = model.Age,
                ContactNumber = model.ContactNumber,
                Email = model.Email,
                AttendeeId = model.AttendeeId
            };
        }

        public ClientDomainModel ToDomain(Client client)
        {
            if (client is null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            return new ClientDomainModel
            {
                Id = client.Id,
                Name = client.Name,
                Surname = client.Surname,
                Age = client.Age,
                ContactNumber = client.ContactNumber,
                Email = client.Email,
                AttendeeId = client.AttendeeId
            };
        }
    }
}
