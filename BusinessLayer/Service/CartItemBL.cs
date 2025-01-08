using BusinessLayer.Interface;
using Model;
using RespositoryLayer.CustomException;
using RespositoryLayer.Entity;
using RespositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

namespace BusinessLayer.Service
{
    public class CartItemBL : ICartItemBL
    {
        private readonly ICartItemRL _cartItemRL;
        private readonly IMapper _mapper;

        public CartItemBL(ICartItemRL cartItemRL, IMapper mapper)
        {
            _cartItemRL = cartItemRL;
            _mapper = mapper;
        }

        public CartItemDTO CreateCartItem(CartItemDTO model)
        {
            var cartItemEntity = _mapper.Map<CartItem>(model);
            var createdCartItem = _cartItemRL.CreateCartItem(cartItemEntity);
            return _mapper.Map<CartItemDTO>(createdCartItem);
        }

        public List<CartItemDTO> GetAllCartItems()
        {
            var cartItems = _cartItemRL.GetAllCartItems();
            return _mapper.Map<List<CartItemDTO>>(cartItems);
        }

        public CartItemDTO GetCartItemById(int id)
        {
            var cartItem = _cartItemRL.GetCartItemById(id);
            if (cartItem == null)
                throw new CartItemException("CartItem not found");
            return _mapper.Map<CartItemDTO>(cartItem);
        }

        public CartItemDTO UpdateCartItem(int id, CartItemDTO model)
        {
            var cartItemEntity = _mapper.Map<CartItem>(model);
            var updatedCartItem = _cartItemRL.UpdateCartItem(id, cartItemEntity);
            if (updatedCartItem == null)
                throw new CartItemException("CartItem not found or update failed");
            return _mapper.Map<CartItemDTO>(updatedCartItem);
        }

        public CartItemDTO DeleteCartItem(int id)
        {
            var deletedCartItem = _cartItemRL.DeleteCartItem(id);
            if (deletedCartItem == null)
                throw new CartItemException("CartItem not found or delete failed");
            return _mapper.Map<CartItemDTO>(deletedCartItem);
        }
    }
}
