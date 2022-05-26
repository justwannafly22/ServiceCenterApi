using MasterApi.Boundary;
using MasterApi.Boundary.Master;
using MasterApi.Boundary.Master.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MasterApi.Controllers
{
    [ApiController]
    [Route("api/v1/masters")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class MasterController : BaseController
    {
        private readonly IMediator _mediator;

        public MasterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns all masters
        /// </summary>
        /// <response code="200">Success. Masters were received successfully</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(List<MasterResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllMastersRequestModel()).ConfigureAwait(false));
        }

        /// <summary>
        /// Returns a master
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success. Master model was received successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Master with provided id cannot be found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(MasterResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] GetMasterByIdRequestModel model)
        {
            var client = await _mediator.Send(model).ConfigureAwait(false);

            if (client is null)
            {
                return NotFound(new BaseResponseModel($"Master with id: {model.Id} doesn`t exist in the database.", HttpStatusCode.NotFound));
            }

            return Ok(client);
        }
        
        /// <summary>
        /// Returns a master
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success. Master model was received successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Master with provided attendee id cannot be found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(MasterResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPost("{attendeeId}")]
        public async Task<IActionResult> GetByAttendeeId([FromRoute] GetMasterByAttendeeIdRequestModel model)
        {
            var client = await _mediator.Send(model).ConfigureAwait(false);

            if (client is null)
            {
                return NotFound(new BaseResponseModel($"Master with attendee id: {model.AttendeeId} doesn`t exist in the database.", HttpStatusCode.NotFound));
            }

            return Ok(client);
        }

        /// <summary>
        /// Create a master
        /// </summary>
        /// <param name="model"></param>
        /// <response code="201">Success. Master was created successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(MasterResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMasterRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new BaseResponseModel(GetErrorMessage(ModelState), HttpStatusCode.BadRequest));
            }

            var addedClient = await _mediator.Send(model).ConfigureAwait(false);

            return CreatedAtAction(nameof(GetById), addedClient);
        }

        /// <summary>
        /// Update a master
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <response code="200">Master was updated successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Master with provided id cannot be found</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(MasterResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateMasterRequestModel requestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new BaseResponseModel(GetErrorMessage(ModelState), HttpStatusCode.BadRequest));
            }

            var model = new UpdateMasterModel(requestModel, id);
            _ = await _mediator.Send(model).ConfigureAwait(false);

            return NoContent();
        }

        /// <summary>
        /// Delete a master
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Master was deleted successfully</response>
        /// <response code="404">Master with provided id cannot be found</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteMasterRequestModel model)
        {
            _ = await _mediator.Send(model).ConfigureAwait(false);

            return NoContent();
        }
    }
}
