using Model;
using RespositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IProductBL
    {

        public Product CreateProduct(ProductDTO model);

        public List<Product> GetAllProducts();

        public Product UpdateProduct(int id, ProductDTO model);

        public Product GetProductById(int id);

        public Product DeleteProduct(int id);



    }
}
