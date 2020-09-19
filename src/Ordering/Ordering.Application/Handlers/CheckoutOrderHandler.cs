﻿using MediatR;
using Ordering.Application.Commands;
using Ordering.Application.Mapper;
using Ordering.Application.Responses;
using Ordering.Core.Entities;
using Ordering.Core.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Handlers
{
    public class CheckoutOrderHandler : IRequestHandler<CheckoutOrderCommand, OrderResponse>
    {
        private IOrderRepository _orderRepository;

        public CheckoutOrderHandler(IOrderRepository orderRepository) =>_orderRepository = orderRepository;
        
        public async Task<OrderResponse> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = OrderMapper.Mapper.Map<Order>(request);
            if (orderEntity == null) throw new ApplicationException("Not mapped");

            var newOrder = await _orderRepository.AddAsync(orderEntity);

            var orderResponse = OrderMapper.Mapper.Map<OrderResponse>(newOrder);

            return orderResponse;
        }
    }
}
