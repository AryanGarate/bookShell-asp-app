using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace Model
{
    public class ProductDTO
    {
        public string ProductName { get; set; }

 
        public string ProductDescription { get; set; } = string.Empty;

      
    
        public int CategoryId { get; set; }
       
       
      
        public long ProductPrice { get; set; }

       
        public long DiscountPrice { get; set; }

        
        public int StockQuantity { get; set; }

      

        public IFormFile? ImageFile { get; set; } // Add this property
        public string ImageUrl { get; set; }
    }

}
