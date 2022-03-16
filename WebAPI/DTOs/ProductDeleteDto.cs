using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class ProductDeleteDto
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
    }
}
