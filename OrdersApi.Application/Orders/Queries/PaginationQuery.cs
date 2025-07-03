using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApi.Application.Orders.Queries
{
    public class PaginationQuery
    {
        public int Page { get; set; } = 1; 
        public int PageSize { get; set; } = 10;
    }
}
