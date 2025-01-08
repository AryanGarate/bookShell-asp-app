using Microsoft.EntityFrameworkCore;
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
using RespositoryLayer.ContextDB;

namespace RespositoryLayer.Service
{
    public class CartRL : ICartRL
    {
        private readonly BookEcommerceContext _context;
        private readonly IMapper _mapper;

        public CartRL(BookEcommerceContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public CartDTO CreateCart(CartDTO model)
        {
            var user = _context.Users.Find(model.UserId);
            if (user == null)
            {
                throw new CartException($"User id {model.UserId} does not exist");
            }

            var cart = _mapper.Map<Cart>(model);
            cart.CreatedAt = DateTime.Now;
            cart.UpdatedAt = DateTime.Now;

            _context.Carts.Add(cart);
            _context.SaveChanges();

            return _mapper.Map<CartDTO>(cart);
        }

        public List<CartDTO> GetAllCarts()
        {
            var cartList = _context.Carts
                .Include(c => c.User)
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .ToList();

            if (cartList.Count == 0)
            {
                throw new CartException("No carts found");
            }

            return _mapper.Map<List<CartDTO>>(cartList);
        }

        public CartDTO GetCartById(int id)
        {
            var cart = _context.Carts
                .Include(c => c.User)
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefault(c => c.Id == id);

            if (cart == null)
            {
                throw new CartException($"Cart with ID {id} does not exist");
            }

            return _mapper.Map<CartDTO>(cart);
        }

        public CartDTO UpdateCart(int id, CartDTO model)
        {
            var cart = _context.Carts.Find(id);
            if (cart == null)
            {
                throw new CartException($"Cart with ID {id} does not exist");
            }

            _mapper.Map(model, cart);
            cart.UpdatedAt = DateTime.Now;

            _context.Carts.Update(cart);
            _context.SaveChanges();

            return _mapper.Map<CartDTO>(cart);
        }

        public CartDTO DeleteCart(int id)
        {
            var cart = _context.Carts.Find(id);
            if (cart == null)
            {
                throw new CartException($"Cart with ID {id} does not exist");
            }

            _context.Carts.Remove(cart);
            _context.SaveChanges();

            return _mapper.Map<CartDTO>(cart);
        }

        public CartDTO GetCartByUserId(int userId)
        {
            var cart = _context.Carts
                .Include(c => c.User)
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                throw new CartException($"Cart for user ID {userId} does not exist");
            }

            return _mapper.Map<CartDTO>(cart);
        }
    }
}

