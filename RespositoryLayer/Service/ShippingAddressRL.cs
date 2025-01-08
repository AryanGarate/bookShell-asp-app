using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model;
using RespositoryLayer.ContextDB;
using RespositoryLayer.Entity;
using RespositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RespositoryLayer.Service
{
    public class ShippingAddressRL : IShippingAddressRL
    {
        private readonly BookEcommerceContext _context;
        private readonly IMapper _mapper;

        public ShippingAddressRL(BookEcommerceContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public ShippingAddress CreateShippingAddress(ShippingAddressDTO model)
        {
            var shippingAddressEntity = _mapper.Map<ShippingAddress>(model);
            _context.ShippingAddresses.Add(shippingAddressEntity);
            _context.SaveChanges();
            return shippingAddressEntity;
        }

        public List<ShippingAddress> GetAllShippingAddresses()
        {
            return _context.ShippingAddresses
                .Include(sa => sa.User)
                .ToList();
        }

        public ShippingAddress GetShippingAddressById(int id)
        {
            return _context.ShippingAddresses
                .Include(sa => sa.User)
                .FirstOrDefault(sa => sa.Id == id);
        }

        public ShippingAddress UpdateShippingAddress(int id, ShippingAddressDTO model)
        {
            var shippingAddressEntity = _context.ShippingAddresses.Find(id);
            if (shippingAddressEntity == null) throw new Exception($"ShippingAddress with ID {id} does not exist");

            _mapper.Map(model, shippingAddressEntity);
            _context.ShippingAddresses.Update(shippingAddressEntity);
            _context.SaveChanges();

            return shippingAddressEntity;
        }

        public ShippingAddress DeleteShippingAddress(int id)
        {
            var shippingAddressEntity = _context.ShippingAddresses.Find(id);
            if (shippingAddressEntity == null) throw new Exception($"ShippingAddress with ID {id} does not exist");

            _context.ShippingAddresses.Remove(shippingAddressEntity);
            _context.SaveChanges();

            return shippingAddressEntity;
        }
    }
}
