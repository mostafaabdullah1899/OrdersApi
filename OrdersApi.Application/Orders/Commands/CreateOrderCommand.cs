using MediatR;
using OrdersApi.Application.DTOS;
using OrdersApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApi.Application.Orders.Commands
{
    public class CreateOrderCommand : IRequest<int>
    {
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<OrderDetailDto> OrderDetails { get; set; }
    }
}
