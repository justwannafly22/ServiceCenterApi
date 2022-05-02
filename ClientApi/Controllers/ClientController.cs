using ClientApi.Boundary;
using ClientApi.Boundary.Client;
using ClientApi.Boundary.Client.RequestModels;
using ClientApi.Boundary.Client.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ClientApi.Controllers
{
    [ApiController]
    [Route("api/v1/clients")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ClientController : BaseController
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns all clients
        /// </summary>
        /// <response code="200">Success. Clients were received successfully</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(List<ClientResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllClientsRequestModel()).ConfigureAwait(false));
        }

        /// <summary>
        /// Returns a client
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success. Client model was received successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Client with provided id cannot be found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(ClientResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] GetClientByIdRequestModel model)
        {
            var client = await _mediator.Send(model).ConfigureAwait(false);

            if (client is null)
            {
                return NotFound(new BaseResponseModel($"Client with id: {model.Id} doesn`t exist in the database.", HttpStatusCode.NotFound));
            }

            return Ok(client);
        }

        /// <summary>
        /// Create a client
        /// </summary>
        /// <param name="model"></param>
        /// <response code="201">Success. Client was created successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(ClientResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClientRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new BaseResponseModel(GetErrorMessage(ModelState), HttpStatusCode.BadRequest));
            }

            var addedClient = await _mediator.Send(model).ConfigureAwait(false);

            return CreatedAtAction(nameof(GetById), addedClient);
        }

        /// <summary>
        /// Update a client
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <response code="200">Client was updated successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Client with provided id cannot be found</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(ClientResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateClientRequestModel requestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new BaseResponseModel(GetErrorMessage(ModelState), HttpStatusCode.BadRequest));
            }

            var model = new UpdateClientModel(requestModel, id);
            _ = await _mediator.Send(model).ConfigureAwait(false);

            return NoContent();
        }

        /// <summary>
        /// Delete a client
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Client was deleted successfully</response>
        /// <response code="404">Client with provided id cannot be found</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteClientRequestModel model)
        {
            _ = await _mediator.Send(model).ConfigureAwait(false);

            return NoContent();
        }
    }
}
