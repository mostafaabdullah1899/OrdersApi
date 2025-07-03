using MediatR;
using OrdersApi.Domain.Entities;
using OrdersApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApi.Application.Orders.Commands
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(request.Id);

            if (existingOrder == null)
            {
                throw new KeyNotFoundException("Order not found.");
            }

            existingOrder.CustomerName = request.CustomerName;
            existingOrder.TotalAmount = request.TotalAmount;
            existingOrder.OrderDate = request.OrderDate;

            existingOrder.OrderDetails.Clear();
            foreach (var orderDetailDto in request.OrderDetails)
            {
                var orderDetail = new OrderDetail
                {
                    ProductName = orderDetailDto.ProductName,
                    Quantity = orderDetailDto.Quantity,
                    UnitPrice = orderDetailDto.UnitPrice
                };
                existingOrder.OrderDetails.Add(orderDetail);
            }

            await _orderRepository.UpdateAsync(existingOrder);

            return existingOrder.Id; 
        }
    }
}