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
    public class SalesBLL : IBLL<SalesDetailDTO, SalesDTO>
    {
        SalesDAO dao = new SalesDAO();
        ProductDAO productdao = new ProductDAO();
        CategoryDAO categorydao = new CategoryDAO();
        CustomerDAO customerdao = new CustomerDAO();


        public bool Delete(SalesDetailDTO entity)
        {
            SALE sales = new SALE();
            sales.ID = entity.SalesID;
            dao.Delete(sales);
            //para corregir la venta y el producto una vez cancelada
            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            product.StockAmount = entity.StockAmount + entity.SalesAmount;
            productdao.Update(product);
            return true;
        }

        public bool GetBack(SalesDetailDTO entity)
        {
            dao.GetBack(entity.SalesID);
            //se corrige el stock
            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            //todo: no llega el stock amount            
            int temp = entity.StockAmount - entity.SalesAmount;
            product.StockAmount = temp;
            productdao.Update(product);
            return true;

        }

        public bool Insert(SalesDetailDTO entity)
        {
            SALE sales = new SALE();
            sales.CategoryID = entity.CategoryID;
            sales.ProductID = entity.ProductID;
            sales.CustomerID = entity.CustomerID;
            sales.ProductSalesPrice = entity.Price;
            sales.ProductSalesAmount = entity.SalesAmount;
            sales.SalesDate = entity.SalesDate;
            dao.Insert(sales);
            //para actualizar el stock de producto ya vendido
            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            int temp = entity.StockAmount-entity.SalesAmount;
            product.StockAmount = temp;
            productdao.Update(product);

            return true;
        }

        public SalesDTO Select()
        {
            SalesDTO dto = new SalesDTO();
            dto.Products = productdao.Select();
            dto.Categories = categorydao.Select();
            dto.Customers = customerdao.Select();
            dto.Sales = dao.Select();
            return dto;
        }

        public SalesDTO Select(bool isDeleted)
        {
            SalesDTO dto = new SalesDTO();
            dto.Products = productdao.Select(isDeleted);
            dto.Categories = categorydao.Select(isDeleted);
            dto.Customers = customerdao.Select(isDeleted);
            dto.Sales = dao.Select(isDeleted);
            return dto;
        }

        public bool Update(SalesDetailDTO entity)
        {
            SALE sales = new SALE();
            sales.ID = entity.SalesID;
            sales.ProductSalesAmount = entity.SalesAmount;
            dao.Update(sales);

            PRODUCT product = new PRODUCT();
            product.ID = entity.ProductID;
            product.StockAmount = entity.StockAmount;
            productdao.Update(product);
            return true;
        }
    }
}
