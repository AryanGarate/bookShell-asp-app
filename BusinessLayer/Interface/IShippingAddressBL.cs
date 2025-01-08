using Model;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IShippingAddressBL
    {
        ShippingAddress CreateShippingAddress(ShippingAddressDTO model);
        ShippingAddress GetShippingAddressById(int id);
        List<ShippingAddress> GetAllShippingAddresses();
        ShippingAddress UpdateShippingAddress(int id, ShippingAddressDTO model);
        ShippingAddress DeleteShippingAddress(int id);
    }
}