using AutoMapper;
using MediatR;
using webapi.CQRS.QueryItem;
using webapi.CQRS.QueryOrder;
using webapi.CQRS.QueryUser;
using webapi.CQRS.ViewModels;
using webapi.Domain.Contracts;
using webapi.Domain.Models;
using webapi.Infrastructure.Database.Entities;
using webapi.Infrastructure.Database.Repository;

namespace webapi.CQRS.QueryHandlers
{
    public class OrderQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderViewModel>>,
       IRequestHandler<GetOrderByIdQuery, OrderViewModel>//from list
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        //from list
        public async Task<IEnumerable<OrderViewModel>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllOrders();

            return _mapper.Map<IEnumerable<OrderViewModel>>(orders);
        }

        public async Task<OrderViewModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderById(request.OrderId);

            return _mapper.Map<OrderViewModel>(order);
        }
    }
}
