using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model;
using RespositoryLayer.ContextDB;
using RespositoryLayer.Entity;
using RespositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RespositoryLayer.Service
{
    public class OrderItemRL : IOrderItemRL
    {
        private readonly BookEcommerceContext _context;
        private readonly IMapper _mapper;

        public OrderItemRL(BookEcommerceContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public OrderItem CreateOrderItem(OrderItemDTO model)
        {
            var orderItemEntity = _mapper.Map<OrderItem>(model);
            _context.OrderItems.Add(orderItemEntity);
            _context.SaveChanges();
            return orderItemEntity;
        }

        public List<OrderItem> GetAllOrderItems()
        {
            return _context.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.Product)
                .ToList();
        }

        public OrderItem GetOrderItemById(int id)
        {
            return _context.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.Product)
                .FirstOrDefault(oi => oi.Id == id);
        }

        public OrderItem UpdateOrderItem(int id, OrderItemDTO model)
        {
            var orderItemEntity = _context.OrderItems.Find(id);
            if (orderItemEntity == null) throw new Exception($"OrderItem with ID {id} does not exist");

            _mapper.Map(model, orderItemEntity);
            _context.OrderItems.Update(orderItemEntity);
            _context.SaveChanges();

            return orderItemEntity;
        }

        public OrderItem DeleteOrderItem(int id)
        {
            var orderItemEntity = _context.OrderItems.Find(id);
            if (orderItemEntity == null) throw new Exception($"OrderItem with ID {id} does not exist");

            _context.OrderItems.Remove(orderItemEntity);
            _context.SaveChanges();

            return orderItemEntity;
        }
    }
}
