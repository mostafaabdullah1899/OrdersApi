using MediatR;
using OrdersApi.Application.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OrdersApi.Application.Orders.Commands
{
    public class UpdateOrderCommand : IRequest<int>
    {
        public int Id { get; set; }  // Order ID
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        [JsonIgnoreAttribute]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<OrderDetailDto> OrderDetails { get; set; }  // Updated Order Details
    }
}
