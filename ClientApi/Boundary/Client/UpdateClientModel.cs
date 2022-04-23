using ClientApi.Boundary.Client.RequestModels;
using ClientApi.Boundary.Client.ResponseModels;
using MediatR;
using System;

namespace ClientApi.Boundary.Client
{
    public class UpdateClientModel : IRequest<ClientResponseModel>
    {
        public UpdateClientModel(UpdateClientRequestModel model)
        {
            Name = model.Name;
            Surname = model.Surname;
            Age = model.Age;
            ContactNumber = model.ContactNumber;
            Email = model.Email;
            AllowEmailNotification = model.AllowEmailNotification;
        }

        public UpdateClientModel(UpdateClientRequestModel model, Guid id)
        {
            Id = id;
            Name = model.Name;
            Surname = model.Surname;
            Age = model.Age;
            ContactNumber = model.ContactNumber;
            Email = model.Email;
            AllowEmailNotification = model.AllowEmailNotification;
        }

        public UpdateClientModel() { }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public bool AllowEmailNotification { get; set; }
    }
}
