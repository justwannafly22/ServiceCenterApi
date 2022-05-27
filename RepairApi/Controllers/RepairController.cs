using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepairApi.Boundary;
using RepairApi.Boundary.Repair;
using RepairApi.Boundary.Repair.RequestModels;
using System.Threading.Tasks;

namespace RepairApi.Controllers
{
    [ApiController]
    [Route("api/v1/repairs")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class RepairController : BaseController
    {
        private readonly IMediator _mediator;

        public RepairController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns a repair
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success. Repair model was received successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Repair with provided id cannot be found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(RepairResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdRepairRequestModel model)
        {
            return Ok(await _mediator.Send(model).ConfigureAwait(false));
        }

        /// <summary>
        /// Returns a repair
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success. Repair model was received successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Repair with provided id cannot be found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(RepairResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllRepairsRequestModel model)
        {
            return Ok(await _mediator.Send(model).ConfigureAwait(false));
        }

        /// <summary>
        /// Create a repair
        /// </summary>
        /// <param name="model"></param>
        /// <response code="201">Success. Repair model was created successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(RepairResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRepairRequestModel model)
        {
            var addedRepair = await _mediator.Send(model).ConfigureAwait(false);

            return CreatedAtAction(nameof(Get), new { id = addedRepair.Id }, addedRepair);
        }
    
        /// <summary>
        /// Create a repair
        /// </summary>
        /// <param name="model"></param>
        /// <response code="201">Success. Repair model was updated successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(RepairResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateRepairRequestModel model)
        {
            var updatedRepair = await _mediator.Send(model).ConfigureAwait(false);

            return Ok(updatedRepair);
        }
    }
}
