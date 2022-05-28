using ClientApi.Boundary.Client;
using ClientApi.Boundary.Client.RequestModels;
using ClientApi.Boundary.Client.ResponseModels;
using Database.Domain;

namespace ClientApi.Factories
{
    public interface IDomainFactory
    {
        ClientDomainModel ToDomain(CreateClientRequestModel model);
        ClientDomainModel ToDomain(UpdateClientRequestModel model);
        ClientDomainModel ToDomain(GetClientByIdRequestModel model);
        ClientDomainModel ToDomain(GetClientByAttendeeIdRequestModel model);
        ClientDomainModel ToDomain(DeleteClientRequestModel model);
        ClientResponseModel ToResponseModel(ClientDomainModel model);
        ClientDomainModel ToDomain(UpdateClientModel model);
    }
}
