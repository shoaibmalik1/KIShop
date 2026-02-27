using KIShop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIShop.DAL.DTO.Response
{
    public class ProductUserResponse
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        //public decimal Discount { get; set; }

        public int Quantity { get; set; }

        public double Rate { get; set; }

        public string MainImage { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<ProductTranslation> Translations { get; set; }

    
    }
}
