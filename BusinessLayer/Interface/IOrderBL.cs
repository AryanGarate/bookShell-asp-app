using Model;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.Interface
{
    public interface IOrderBL
    {
        OrderDTO CreateOrder(OrderDTO model);
        List<OrderDTO> GetAllOrders();
        OrderDTO GetOrderById(int id);
        OrderDTO UpdateOrder(int id, OrderDTO model);
        OrderDTO DeleteOrder(int id);
    }
}
