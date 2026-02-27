using KIShop.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KIShop.DAL.DTO.Response
{
    public class ProductResponse
    {
        public int Id { get; set; }


        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Status Status { get; set; }

        public string MainImage {  get; set; }

  

        public List<CategoryTranslationResponse> Translations { get; set; }
    }
}
