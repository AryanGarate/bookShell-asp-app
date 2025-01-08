using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLayer.Interface;
using Model;
using RespositoryLayer.Interface;
using RespositoryLayer.Entity;

using AutoMapper;
using RespositoryLayer.CustomException;

namespace BusinessLayer.Service
{
    public class OrderItemBL : IOrderItemBL
    {
        private readonly IOrderItemRL _orderItemRL;
        private readonly IMapper _mapper;

        public OrderItemBL(IOrderItemRL orderItemRL, IMapper mapper)
        {
            _orderItemRL = orderItemRL;
            _mapper = mapper;
        }

        public OrderItemDTO CreateOrderItem(OrderItemDTO model)
        {
            var orderItemEntity = _mapper.Map<OrderItem>(model);
            var createdOrderItem = _orderItemRL.CreateOrderItem(orderItemEntity);
            return _mapper.Map<OrderItemDTO>(createdOrderItem);
        }

        public List<OrderItemDTO> GetAllOrderItems()
        {
            var orderItems = _orderItemRL.GetAllOrderItems();
            return _mapper.Map<List<OrderItemDTO>>(orderItems);
        }

        public OrderItemDTO GetOrderItemById(int id)
        {
            var orderItem = _orderItemRL.GetOrderItemById(id);
            if (orderItem == null)
                throw new OrderItemException("OrderItem not found");
            return _mapper.Map<OrderItemDTO>(orderItem);
        }

        public OrderItemDTO UpdateOrderItem(int id, OrderItemDTO model)
        {
            var orderItemEntity = _mapper.Map<OrderItem>(model);
            var updatedOrderItem = _orderItemRL.UpdateOrderItem(id, orderItemEntity);
            if (updatedOrderItem == null)
                throw new OrderItemException("OrderItem not found or update failed");
            return _mapper.Map<OrderItemDTO>(updatedOrderItem);
        }

        public OrderItemDTO DeleteOrderItem(int id)
        {
            var deletedOrderItem = _orderItemRL.DeleteOrderItem(id);
            if (deletedOrderItem == null)
                throw new OrderItemException("OrderItem not found or delete failed");
            return _mapper.Map<OrderItemDTO>(deletedOrderItem);
        }
    }
}

