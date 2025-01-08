using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using Model;
using RespositoryLayer.Entity;

namespace RespositoryLayer.Interface
{
    public interface IOrderRL
    {
        Order CreateOrder(OrderDTO model);
        List<Order> GetAllOrders();
        Order GetOrderById(int id);
        Order UpdateOrder(int id, OrderDTO model);
        Order DeleteOrder(int id);
    }
}
