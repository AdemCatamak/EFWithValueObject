using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using EFWithValueObject.Api.Controllers.Requests;
using EFWithValueObject.Api.Db;
using EFWithValueObject.Api.Db.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFWithValueObject.Api.Controllers
{
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public OrderController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] PostOrderHttpRequest? postOrderHttpRequest)
        {
            CancellationToken cancellationToken = CancellationToken.None;

            Order order = new Order(postOrderHttpRequest?.Username ?? string.Empty,
                                    new Address(postOrderHttpRequest?.Country ?? string.Empty,
                                                postOrderHttpRequest?.City ?? string.Empty));

            await _appDbContext.Orders.AddAsync(order, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return StatusCode((int) HttpStatusCode.Created, order.Id);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] GetOrdersHttpRequest? getOrdersHttpRequest)
        {
            CancellationToken cancellationToken = CancellationToken.None;

            IQueryable<Order> orders = _appDbContext.Orders.AsQueryable();

            if (getOrdersHttpRequest?.OrderId != null)
                orders = orders.Where(o => o.Id == getOrdersHttpRequest.OrderId.Value);

            if (getOrdersHttpRequest?.Username != null)
                orders = orders.Where(o => o.Username == getOrdersHttpRequest.Username);

            if (getOrdersHttpRequest?.Country != null)
                orders = orders.Where(o => o.Address.Country == getOrdersHttpRequest.Country);

            if (getOrdersHttpRequest?.City != null)
                orders = orders.Where(o => o.Address.City == getOrdersHttpRequest.City);
            
            List<Order> orderList = await orders.ToListAsync(cancellationToken);

            if (!orderList.Any())
                return StatusCode((int) HttpStatusCode.NotFound);

            return StatusCode((int) HttpStatusCode.OK, orderList);
        }
    }
}