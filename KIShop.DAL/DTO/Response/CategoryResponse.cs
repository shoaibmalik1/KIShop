using KIShop.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIShop.DAL.DTO.Response
{
    public class CategoryResponse
    {
        public ApplicationUser User {  get; set; } 
        
        public int Id { get; set; }

        public Status Status { get; set; }

        public List<CategoryTranslationResponse> Translations { get; set; }
    }
}
