using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIShop.DAL.Models
{
    public class BaseModel
    {
        public int Id { get; set; }

        public Status Status { get; set; }

        public string CraetedBy {  get; set; }

        public DateTime CreatedAt { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        [ForeignKey("CraetedBy")]
        public ApplicationUser User { get; set; }
    }
}
