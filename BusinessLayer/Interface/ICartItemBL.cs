using Model;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ICartItemBL
    {
        CartItemDTO CreateCartItem(CartItemDTO model);
        List<CartItemDTO> GetAllCartItems();
        CartItemDTO GetCartItemById(int id);
        CartItemDTO UpdateCartItem(int id, CartItemDTO model);
        CartItemDTO DeleteCartItem(int id);
    }
}
