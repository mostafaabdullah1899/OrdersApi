using MediatR;
using OrdersApi.Application.DTOS;
using OrdersApi.Domain.Entities;
using OrdersApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApi.Application.Orders.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        //private readonly IOrderDetailRepository _orderDetailRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
          //  _orderDetailRepository = orderDetailRepository;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                OrderDate = DateTime.Now,
                CustomerName = request.CustomerName,
                TotalAmount = request.TotalAmount,
                OrderDetails = request.OrderDetails.Select(od => new OrderDetail
                {
                    ProductName = od.ProductName,
                    Quantity = od.Quantity,
                    UnitPrice = od.UnitPrice
                }).ToList()
            };

            await _orderRepository.AddAsync(order);

            return order.Id;
        }
    }
}
