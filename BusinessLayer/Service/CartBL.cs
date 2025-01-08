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
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Service
{
    //public class CartBL : ICartBL
    //{
    //    private readonly ICartRL _cartRL;
    //    private readonly IMapper _mapper;

    //    public CartBL(ICartRL cartRL, IMapper mapper)
    //    {
    //        _cartRL = cartRL;
    //        _mapper = mapper;
    //    }

    //    public CartDTO CreateCart(CartDTO model)
    //    {
    //        //var cartEntity = _mapper.Map<Cart>(model);
    //        //var createdCart = _cartRL.CreateCart(cartEntity);
    //        //return _mapper.Map<CartDTO>(createdCart);
    //        var cartEntity = _mapper.Map<Cart>(model); // Convert DTO to Entity
    //        var createdCart = _cartRL.CreateCart(cartEntity); // Pass Entity to Repository
    //        return _mapper.Map<CartDTO>(createdCart); // Convert Entity back to DTO
    //    }

    //    public List<CartDTO> GetAllCarts()
    //    {
    //        var carts = _cartRL.GetAllCarts();
    //        return _mapper.Map<List<CartDTO>>(carts);
    //    }

    //    public CartDTO GetCartById(int id)
    //    {
    //        var cart = _cartRL.GetCartById(id);
    //        if (cart == null)
    //            throw new CartException("Cart not found");
    //        return _mapper.Map<CartDTO>(cart);
    //    }

    //    public CartDTO UpdateCart(int id, CartDTO model)
    //    {
    //        var cartEntity = _mapper.Map<Cart>(model);
    //        var updatedCart = _cartRL.UpdateCart(id, cartEntity);
    //        if (updatedCart == null)
    //            throw new CartException("Cart not found or update failed");
    //        return _mapper.Map<CartDTO>(updatedCart);
    //    }

    //    public CartDTO DeleteCart(int id)
    //    {
    //        var deletedCart = _cartRL.DeleteCart(id);
    //        if (deletedCart == null)
    //            throw new CartException("Cart not found or delete failed");
    //        return _mapper.Map<CartDTO>(deletedCart);
    //    }

    //    public CartDTO GetCartByUserId(int userId)
    //    {
    //        var cart = _cartRL.GetCartByUserId(userId);
    //        if (cart == null)
    //            throw new CartException("Cart for user not found");
    //        return _mapper.Map<CartDTO>(cart);
    //    }
    //}
    public class CartBL : ICartBL
    {
        private readonly ICartRL _cartRL;
        private readonly IMapper _mapper;

        public CartBL(ICartRL cartRL, IMapper mapper)
        {
            _cartRL = cartRL;
            _mapper = mapper;
        }

        public CartDTO CreateCart(CartDTO model)
        {
            var cartEntity = _mapper.Map<Cart>(model);
            var createdCart = _cartRL.CreateCart(cartEntity);
            return _mapper.Map<CartDTO>(createdCart);
        }

        public List<CartDTO> GetAllCarts()
        {
            var carts = _cartRL.GetAllCarts();
            return _mapper.Map<List<CartDTO>>(carts);
        }

        public CartDTO GetCartById(int id)
        {
            var cart = _cartRL.GetCartById(id);
            if (cart == null)
                throw new CartException("Cart not found");
            return _mapper.Map<CartDTO>(cart);
        }

        public CartDTO UpdateCart(int id, CartDTO model)
        {
            var cartEntity = _mapper.Map<Cart>(model);
            var updatedCart = _cartRL.UpdateCart(id, cartEntity);
            if (updatedCart == null)
                throw new CartException("Cart not found or update failed");
            return _mapper.Map<CartDTO>(updatedCart);
        }

        public CartDTO DeleteCart(int id)
        {
            var deletedCart = _cartRL.DeleteCart(id);
            if (deletedCart == null)
                throw new CartException("Cart not found or delete failed");
            return _mapper.Map<CartDTO>(deletedCart);
        }

        public CartDTO GetCartByUserId(int userId)
        {
            var cart = _cartRL.GetCartByUserId(userId);
            if (cart == null)
                throw new CartException("Cart for user not found");
            return _mapper.Map<CartDTO>(cart);
        }
    }

}
