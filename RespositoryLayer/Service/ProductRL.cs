using Microsoft.EntityFrameworkCore;
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

namespace RespositoryLayer.Service
{
    public class ProductRL : IProductRL
    {
        public BookEcommerceContext _context;

        public ProductRL(BookEcommerceContext context)
        {
            //_context = context;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }



        public Product CreateProduct(ProductDTO model)
        {
             var category = _context.categories.Find(model.CategoryId);

            if (category == null) {

                throw new ProductException($"Category id {model.CategoryId} does not exist");
             
            }

            Product product = new Product()
            {
                ProductName = model.ProductName,
                ProductDescription = model.ProductDescription,
                ProductPrice = model.ProductPrice,
                DiscountPrice = model.DiscountPrice,
                StockQuantity = model.StockQuantity,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,



            };


            _context.Add(product);

            _context.SaveChanges();

            return product;
        }

        public List<Product> GetAllProducts()
        {
            
            try
            {
                var productList = _context.products
                                   .Include(p => p.Category) // Eagerly load the Category entity
                                   .ToList();
                if (productList.Count == 0)
                {
                    throw new ProductException("No products found");
                }
                return productList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product UpdateProduct(int id, ProductDTO model)
        {
            try
            {
                var product = _context.products.Find(id);
                if (product == null)
                {
                    throw new ProductException($"Product with ID {id} does not exist");
                }

                var category = _context.categories.Find(model.CategoryId);
                if (category == null)
                {
                    throw new ProductException($"Category with ID {model.CategoryId} does not exist");
                }

                product.ProductName = model.ProductName;
                product.ProductDescription = model.ProductDescription;
                product.ProductPrice = model.ProductPrice;
                product.DiscountPrice = model.DiscountPrice;
                product.StockQuantity = model.StockQuantity;
                product.ImageUrl = model.ImageUrl;
                product.CategoryId = model.CategoryId;
                product.UpdatedAt = DateTime.Now; // Update timestamp

                _context.products.Update(product);
                _context.SaveChanges();

                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product GetProductById(int id)
        {
            try
            {
                var product = _context.products
                                       .Include(p => p.Category) // Include Category if needed
                                       .FirstOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    throw new ProductException($"Product with ID {id} does not exist");
                }
                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Product DeleteProduct(int id)
        {
            try
            {
                var product = _context.products.Find(id);
                if (product == null)
                {
                    throw new ProductException($"Product with ID {id} does not exist");
                }

                _context.products.Remove(product);
                _context.SaveChanges();

                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
