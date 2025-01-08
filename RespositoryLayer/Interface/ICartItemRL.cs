using Model;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace RespositoryLayer.Interface
{
    public interface ICartItemRL
    {
        CartItemDTO CreateCartItem(CartItemDTO model);
        List<CartItemDTO> GetAllCartItems();
        CartItemDTO GetCartItemById(int id);
        CartItemDTO UpdateCartItem(int id, CartItemDTO model);
        CartItemDTO DeleteCartItem(int id);
    }
}
