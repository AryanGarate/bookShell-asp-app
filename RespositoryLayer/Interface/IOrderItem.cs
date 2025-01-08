using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using RespositoryLayer.Entity;

namespace RespositoryLayer.Interface
{
    public interface IOrderItemRL
    {
        OrderItem CreateOrderItem(OrderItemDTO model);
        List<OrderItem> GetAllOrderItems();
        OrderItem GetOrderItemById(int id);
        OrderItem UpdateOrderItem(int id, OrderItemDTO model);
        OrderItem DeleteOrderItem(int id);
    }
}
