using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrdersApi.Application.Orders.Commands;
using OrdersApi.Application.Orders.Queries;

namespace OrdersApi.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            var orderId = await _mediator.Send(command);
            return Ok(orderId);
            //return CreatedAtAction(nameof(GetOrderById), new { id = orderId }, null);
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] PaginationQuery paginationQuery)
        {
            var query = new GetOrdersQuery
            {
                Pagination = paginationQuery
            };

            var orders = await _mediator.Send(query);
            return Ok(orders);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderCommand command)
        {
            if (id != command.Id) return BadRequest();

            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _mediator.Send(new DeleteOrderCommand { Id = id });
            return NoContent();
        }
    }
}
