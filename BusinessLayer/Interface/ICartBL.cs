using Model;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.Interface
{
    public interface ICartBL
    {
        CartDTO CreateCart(CartDTO model);
        List<CartDTO> GetAllCarts();
        CartDTO GetCartById(int id);
        CartDTO UpdateCart(int id, CartDTO model);
        CartDTO DeleteCart(int id);
        CartDTO GetCartByUserId(int userId);
    }
}
