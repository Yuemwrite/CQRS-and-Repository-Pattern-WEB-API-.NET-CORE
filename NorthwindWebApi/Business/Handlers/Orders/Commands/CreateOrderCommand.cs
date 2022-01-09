using Core.Wrappers;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers.Orders.Commands
{
    public class CreateOrderCommand : IRequest<IResponse>
    {
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public int ShipperId { get; set; }

        public int EmployeeId { get; set; }

        public string CustomerId { get; set; }

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, IResponse>
        {
            private readonly IOrderRepository _orderRepository;

            public CreateOrderCommandHandler(IOrderRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }
            public async Task<IResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                Order addedOrder = new Order();
                addedOrder.ShipName = request.ShipName;
                addedOrder.ShipperId = request.ShipperId;
                addedOrder.ShipCity = request.ShipCity;
                addedOrder.ShipCountry = request.ShipCountry;
                addedOrder.EmployeeId = request.EmployeeId;
                addedOrder.CustomerId = request.CustomerId;
                addedOrder.ShipAddress = request.ShipAddress;
                addedOrder.ShipRegion = request.ShipRegion;
                addedOrder.ShipPostalCode = request.ShipPostalCode;

                _orderRepository.Add(addedOrder);
                await _orderRepository.SaveChangesAsync();

                return new Response<Order>(addedOrder);
            }
        }
    }
}
