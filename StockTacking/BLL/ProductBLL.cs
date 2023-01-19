using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTacking.DAL;
using StockTacking.DAL.DTO;
using StockTacking.DAL.DAO;

namespace StockTacking.BLL
{
    public class ProductBLL : IBLL<ProductDetailDTO, ProductDTO>
    {
        CategoryDAO categoryDao = new CategoryDAO();
        ProductDAO dao = new ProductDAO();

        public bool Delete(ProductDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(ProductDetailDTO entity)
        {
            PRODUCT product = new PRODUCT();            
            product.CategoryID = entity.CategoryID;
            product.ProductName = entity.ProductName;
            product.Price = entity.Price;
            return dao.Insert(product);

        }

        public ProductDTO Select()
        {
            ProductDTO dto = new ProductDTO();
            dto.Categories = categoryDao.Select();
            dto.Products = dao.Select();
            return dto;

        }

        public bool Update(ProductDetailDTO entity)
        {
            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            product.ProductName = entity.ProductName;
            product.CategoryID = entity.CategoryID;
            product.StockAmount = entity.StockAmount;
            product.Price = entity.Price;
            return dao.Update(product);
        }
    }
}
