using MasterApi.Boundary.Master.RequestModels;
using MediatR;
using System;

namespace MasterApi.Boundary.Master
{
    public class UpdateMasterModel : IRequest<MasterResponseModel>
    {
        public UpdateMasterModel(UpdateMasterRequestModel model)
        {
            Name = model.Name;
            Surname = model.Surname;
            Age = model.Age;
            ContactNumber = model.ContactNumber;
        }

        public UpdateMasterModel(UpdateMasterRequestModel model, Guid id)
        {
            Id = id;
            Name = model.Name;
            Surname = model.Surname;
            Age = model.Age;
            ContactNumber = model.ContactNumber;
        }

        public UpdateMasterModel() { }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string ContactNumber { get; set; }
    }
}
