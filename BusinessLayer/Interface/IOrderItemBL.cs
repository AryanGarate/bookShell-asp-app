using Model;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.Interface
{
    public interface IOrderItemBL
    {
        OrderItemDTO CreateOrderItem(OrderItemDTO model);
        List<OrderItemDTO> GetAllOrderItems();
        OrderItemDTO GetOrderItemById(int id);
        OrderItemDTO UpdateOrderItem(int id, OrderItemDTO model);
        OrderItemDTO DeleteOrderItem(int id);
    }
}
