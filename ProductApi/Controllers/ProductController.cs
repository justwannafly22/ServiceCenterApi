using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Boundary;
using ProductApi.Boundary.RequestModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns all products
        /// </summary>
        /// <response code="200">Success. Products were received successfully</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(List<ProductResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _mediator.Send(new GetAllProductsRequestModel()).ConfigureAwait(false);

            return Ok(products);
        }

        /// <summary>
        /// Returns a product
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success. Product model was received successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Product with provided id cannot be found</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(ProductResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdProductRequestModel request)
        {
            var product = await _mediator.Send(request).ConfigureAwait(false);

            if (product is null)
            {
                return NotFound(new BaseResponseModel($"The product with id: {request.Id} doesn`t exist in the database.", HttpStatusCode.NotFound));
            }

            return Ok(product);
        }

        /// <summary>
        /// Create a product
        /// </summary>
        /// <param name="model"></param>
        /// <response code="200">Success. Products received successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(ProductResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPost("{clientId}")]
        public async Task<IActionResult> GetProductsByClientId([FromRoute] GetProductsByClientIdRequestModel request)
        {
            var products = await _mediator.Send(request).ConfigureAwait(false);

            return Ok(products);
        }
        
        /// <summary>
        /// Create a product
        /// </summary>
        /// <param name="model"></param>
        /// <response code="201">Success. Product model was created successfully</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(typeof(ProductResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequestModel request)
        {
            var addedProduct = await _mediator.Send(request).ConfigureAwait(false);

            return CreatedAtAction(nameof(Get), addedProduct);
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Product was deleted successfully</response>
        /// <response code="404">Product with provided id cannot be found</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductRequestModel request)
        {
            await _mediator.Send(request).ConfigureAwait(false);

            return NoContent();
        }

        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <response code="200">Product was updated successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Product with provided id cannot be found</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductRequestModel request)
        {
            var model = new UpdateProductModel(id, request);
            var updatedProduct = await _mediator.Send(model).ConfigureAwait(false);

            return RedirectToAction(nameof(Get), updatedProduct);
        }
    }
}
