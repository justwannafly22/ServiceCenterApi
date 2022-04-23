using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReplacedPartApi.Boundary;
using ReplacedPartApi.Boundary.ReplacedParts;
using ReplacedPartApi.Boundary.ReplacedParts.RequestModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ReplacedPartApi.Controllers
{
    [ApiController]
    [Route("api/v1/replacedParts")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ReplacedPartController : BaseController
    {
        private readonly IMediator _mediator;

        public ReplacedPartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns a replaced parts by required Id
        /// </summary>
        /// <response code="200">Success. Replaced parts were received successfully</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(List<ReplacedPartResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Guid requiredId, [FromQuery] RequiredIdType type)
        {
            var request = new GetAllReplacedPartRequestModel(requiredId, type);

            return Ok(await _mediator.Send(request).ConfigureAwait(false));
        }

        /// <summary>
        /// Returns a replaced part
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success. Replaced part model was received successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Replaced part  with provided id cannot be found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(ReplacedPartResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdReplacedPartRequestModel request)
        {
            var response = await _mediator.Send(request).ConfigureAwait(false);
            if (response is null)
            {
                return NotFound(new BaseResponseModel($"ReplacedPart with id: {request.Id} doesn`t exist in the database.", HttpStatusCode.NotFound));
            }

            return Ok(await _mediator.Send(request).ConfigureAwait(false));
        }

        /// <summary>
        /// Create a replaced parts
        /// </summary>
        /// <param name="models"></param>
        /// <response code="201">Success. Replaced part models were created successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(ReplacedPartResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReplacedPartRequestModel request)
        {
            var addedReplacedPart = await _mediator.Send(request).ConfigureAwait(false);

            return CreatedAtAction(nameof(Get), addedReplacedPart);
        }

        /// <summary>
        /// Update a replaced part
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <response code="200">Replaced part was updated successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Replaced part with provided id cannot be found</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateReplacedPartRequestModel request)
        {
            var response = await _mediator.Send(new GetByIdReplacedPartRequestModel(id)).ConfigureAwait(false);
            if (response is null)
            {
                return NotFound(new BaseResponseModel($"ReplacedPart with id: {id} doesn`t exist in the database.", HttpStatusCode.NotFound));
            }

            var model = new UpdateReplacedPartModel(request, id);
            var updatedReplacedPart = await _mediator.Send(model).ConfigureAwait(false);

            return RedirectToAction(nameof(Get), updatedReplacedPart);
        }

        /// <summary>
        /// Delete a replaced part
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Replaced part was deleted successfully</response>
        /// <response code="404">Replaced part with provided id cannot be found</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteReplacedPartRequestModel request)
        {
            var response = await _mediator.Send(new GetByIdReplacedPartRequestModel(request.Id)).ConfigureAwait(false);
            if (response is null)
            {
                return NotFound(new BaseResponseModel($"ReplacedPart with id: {request.Id} doesn`t exist in the database.", HttpStatusCode.NotFound));
            }

            await _mediator.Send(request).ConfigureAwait(false);

            return NoContent();
        }
    }
}
