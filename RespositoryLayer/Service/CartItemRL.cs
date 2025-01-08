using Model;
using RespositoryLayer.ContextDB;
using RespositoryLayer.CustomException;
using RespositoryLayer.Entity;
using RespositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

namespace RespositoryLayer.Service
{
    public class CartItemRL : ICartItemRL
    {
        private readonly BookEcommerceContext _context;
        private readonly IMapper _mapper;

        public CartItemRL(BookEcommerceContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public CartItemDTO CreateCartItem(CartItemDTO model)
        {
            var cart = _context.Carts.Find(model.CartId);
            if (cart == null)
            {
                throw new CartItemException($"Cart id {model.CartId} does not exist");
            }

            var product = _context.products.Find(model.ProductId);
            if (product == null)
            {
                throw new CartItemException($"Product id {model.ProductId} does not exist");
            }

            var cartItem = _mapper.Map<CartItem>(model);
            _context.CartItems.Add(cartItem);
            _context.SaveChanges();

            return _mapper.Map<CartItemDTO>(cartItem);
        }

        public List<CartItemDTO> GetAllCartItems()
        {
            var cartItemList = _context.CartItems
                .Include(ci => ci.Cart)
                .Include(ci => ci.Product)
                .ToList();

            if (cartItemList.Count == 0)
            {
                throw new CartItemException("No cart items found");
            }

            return _mapper.Map<List<CartItemDTO>>(cartItemList);
        }

        public CartItemDTO GetCartItemById(int id)
        {
            var cartItem = _context.CartItems
                .Include(ci => ci.Cart)
                .Include(ci => ci.Product)
                .FirstOrDefault(ci => ci.Id == id);

            if (cartItem == null)
            {
                throw new CartItemException($"Cart item with ID {id} does not exist");
            }

            return _mapper.Map<CartItemDTO>(cartItem);
        }

        public CartItemDTO UpdateCartItem(int id, CartItemDTO model)
        {
            var cartItem = _context.CartItems.Find(id);
            if (cartItem == null)
            {
                throw new CartItemException($"Cart item with ID {id} does not exist");
            }

            _mapper.Map(model, cartItem);
            _context.CartItems.Update(cartItem);
            _context.SaveChanges();

            return _mapper.Map<CartItemDTO>(cartItem);
        }

        public CartItemDTO DeleteCartItem(int id)
        {
            var cartItem = _context.CartItems.Find(id);
            if (cartItem == null)
            {
                throw new CartItemException($"Cart item with ID {id} does not exist");
            }

            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();

            return _mapper.Map<CartItemDTO>(cartItem);
        }
    }
}

