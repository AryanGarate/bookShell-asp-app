using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLayer.Interface;
using Model;
using RespositoryLayer.Interface;
using System.Collections.Generic;
using RespositoryLayer.Entity;

using AutoMapper;
using RespositoryLayer.CustomException;

namespace BusinessLayer.Service
{
    public class OrderBL : IOrderBL
    {
        private readonly IOrderRL _orderRL;
        private readonly IMapper _mapper;

        public OrderBL(IOrderRL orderRL, IMapper mapper)
        {
            _orderRL = orderRL;
            _mapper = mapper;
        }

        public OrderDTO CreateOrder(OrderDTO model)
        {
            var orderEntity = _mapper.Map<Order>(model);
            var createdOrder = _orderRL.CreateOrder(orderEntity);
            return _mapper.Map<OrderDTO>(createdOrder);
        }

        public List<OrderDTO> GetAllOrders()
        {
            var orders = _orderRL.GetAllOrders();
            return _mapper.Map<List<OrderDTO>>(orders);
        }

        public OrderDTO GetOrderById(int id)
        {
            var order = _orderRL.GetOrderById(id);
            if (order == null)
                throw new OrderException("Order not found");
            return _mapper.Map<OrderDTO>(order);
        }

        public OrderDTO UpdateOrder(int id, OrderDTO model)
        {
            var orderEntity = _mapper.Map<Order>(model);
            var updatedOrder = _orderRL.UpdateOrder(id, orderEntity);
            if (updatedOrder == null)
                throw new OrderException("Order not found or update failed");
            return _mapper.Map<OrderDTO>(updatedOrder);
        }

        public OrderDTO DeleteOrder(int id)
        {
            var deletedOrder = _orderRL.DeleteOrder(id);
            if (deletedOrder == null)
                throw new OrderException("Order not found or delete failed");
            return _mapper.Map<OrderDTO>(deletedOrder);
        }
    }
}
