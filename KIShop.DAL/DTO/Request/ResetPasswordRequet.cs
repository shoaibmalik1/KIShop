using KIShop.DAL.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIShop.DAL.DTO.Request
{
    public class ResetPasswordRequet
    {
        public string code { get; set; }
        public string newPassword { get; set; }
        public string Email { get; set; }
    }
}
