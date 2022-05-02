using MediatR;

namespace MasterApi.Boundary.Master.RequestModels
{
    public class CreateMasterRequestModel : IRequest<MasterResponseModel>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string ContactNumber { get; set; }
    }
}
