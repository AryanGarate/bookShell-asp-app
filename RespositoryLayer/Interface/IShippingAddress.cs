using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
using RespositoryLayer.Entity;

namespace RespositoryLayer.Interface
{
    public interface IShippingAddressRL
    {
        ShippingAddress CreateShippingAddress(ShippingAddressDTO model);
        List<ShippingAddress> GetAllShippingAddresses();
        ShippingAddress GetShippingAddressById(int id);
        ShippingAddress UpdateShippingAddress(int id, ShippingAddressDTO model);
        ShippingAddress DeleteShippingAddress(int id);
    }
}

