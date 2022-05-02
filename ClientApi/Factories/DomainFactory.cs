using ClientApi.Boundary.Client;
using ClientApi.Boundary.Client.RequestModels;
using ClientApi.Boundary.Client.ResponseModels;
using ClientApi.Domain;
using System;

namespace ClientApi.Factories
{
    public class DomainFactory : IDomainFactory
    {
        public ClientDomainModel ToDomain(CreateClientRequestModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new ClientDomainModel
            {
                Name = model.Name,
                Surname = model.Surname,
                Age = model.Age,
                ContactNumber = model.ContactNumber,
                Email = model.Email,
                MasterId = model.MasterId
            };
        }

        public ClientDomainModel ToDomain(UpdateClientModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new ClientDomainModel
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Age = model.Age,
                ContactNumber = model.ContactNumber,
                Email = model.Email,
                MasterId = model.MasterId
            };
        }

        public ClientDomainModel ToDomain(UpdateClientRequestModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new ClientDomainModel
            {
                Name = model.Name,
                Surname = model.Surname,
                Age = model.Age,
                ContactNumber = model.ContactNumber,
                Email = model.Email,
                MasterId = model.MasterId
            };
        }

        public ClientDomainModel ToDomain(GetClientByIdRequestModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new ClientDomainModel
            {
                Id = model.Id
            };
        }

        public ClientDomainModel ToDomain(DeleteClientRequestModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new ClientDomainModel
            {
                Id = model.Id
            };
        }

        public ClientResponseModel ToResponseModel(ClientDomainModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return new ClientResponseModel
            {
                Id = model.Id,
                FullName = string.Join(' ', model.Name, model.Surname),
                Age = model.Age,
                ContactNumber = model.ContactNumber,
                Email = model.Email,
                MasterId = model.MasterId
            };
        }
    }
}
