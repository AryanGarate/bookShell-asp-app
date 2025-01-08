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
    public class OrderRL : IOrderRL
    {
        private readonly BookEcommerceContext _context;
        private readonly IMapper _mapper;

        public OrderRL(BookEcommerceContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Order CreateOrder(OrderDTO model)
        {
            var orderEntity = _mapper.Map<Order>(model);
            _context.Orders.Add(orderEntity);
            _context.SaveChanges();
            return orderEntity;
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders
                .Include(o => o.User)
                .Include(o => o.Transaction)
                .Include(o => o.ShippingAddress)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToList();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders
                .Include(o => o.User)
                .Include(o => o.Transaction)
                .Include(o => o.ShippingAddress)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefault(o => o.Id == id);
        }

        public Order UpdateOrder(int id, OrderDTO model)
        {
            var orderEntity = _context.Orders.Find(id);
            if (orderEntity == null) throw new Exception($"Order with ID {id} does not exist");

            _mapper.Map(model, orderEntity);
            _context.Orders.Update(orderEntity);
            _context.SaveChanges();

            return orderEntity;
        }

        public Order DeleteOrder(int id)
        {
            var orderEntity = _context.Orders.Find(id);
            if (orderEntity == null) throw new Exception($"Order with ID {id} does not exist");

            _context.Orders.Remove(orderEntity);
            _context.SaveChanges();

            return orderEntity;
        }
    }
}

