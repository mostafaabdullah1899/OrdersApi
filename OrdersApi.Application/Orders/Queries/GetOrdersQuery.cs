using MediatR;
using OrdersApi.Application.DTOS;
using OrdersApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApi.Application.Orders.Queries
{
    public class GetOrdersQuery : IRequest<List<OrderDto>>
    {
        public PaginationQuery Pagination { get; set; }
    }
}
