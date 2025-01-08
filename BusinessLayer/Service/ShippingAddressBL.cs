using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessLayer.Interface;
using Model;
using RespositoryLayer.Interface;
using RespositoryLayer.Entity;

namespace BusinessLayer.Service
{
    public class ShippingAddressBL : IShippingAddressBL
    {
        private readonly IShippingAddressRL _shippingAddressRL;

        public ShippingAddressBL(IShippingAddressRL shippingAddressRL)
        {
            _shippingAddressRL = shippingAddressRL;
        }

        public ShippingAddress CreateShippingAddress(ShippingAddressDTO model)
        {
            return _shippingAddressRL.CreateShippingAddress(model);
        }

        public List<ShippingAddress> GetAllShippingAddresses()
        {
            return _shippingAddressRL.GetAllShippingAddresses();
        }

        public ShippingAddress GetShippingAddressById(int id)
        {
            return _shippingAddressRL.GetShippingAddressById(id);
        }

        public ShippingAddress UpdateShippingAddress(int id, ShippingAddressDTO model)
        {
            return _shippingAddressRL.UpdateShippingAddress(id, model);
        }

        public ShippingAddress DeleteShippingAddress(int id)
        {
            return _shippingAddressRL.DeleteShippingAddress(id);
        }
    }
}
