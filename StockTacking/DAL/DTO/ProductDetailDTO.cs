using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTacking.DAL.DTO
{
    public class ProductDetailDTO
    {
        public int ProductID { get; set; }

        public int CategoryID { get; set; }

        public string ProductName { get; set; }

        public string CategoryName { get; set; }

        public int StockAmount { get; set; }

        public decimal Price { get; set; }

    }
}
