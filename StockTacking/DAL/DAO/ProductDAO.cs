using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTacking.DAL.DTO;
using StockTacking.DAL;
using System.Diagnostics;

namespace StockTacking.DAL.DAO
{
    public class ProductDAO : StockContext, IDAO<PRODUCT, ProductDetailDTO>
    {
        public bool Delete(PRODUCT entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(PRODUCT entity)
        {
            try
            {
                db.PRODUCTs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ProductDetailDTO> Select()
        {
            try
            {
                List<ProductDetailDTO> products = new List<ProductDetailDTO>();
                var list = (from p in db.PRODUCTs
                            join c in db.CATEGORies
                            on p.CategoryID equals c.ID
                            select new
                            {
                                ProductID = p.ID,
                                CategoryID = c.ID,
                                productName = p.ProductName,
                                CategoryName = c.CategoryName,
                                StockAmount = p.StockAmount,
                                Price = p.Price
                            }).OrderBy(x => x.productName).ToList();
                //se formatea la lista a un objeto de la clase ProductDetailDTO
                foreach (var item in list)
                {
                    ProductDetailDTO dto = new ProductDetailDTO();
                    dto.ProductID = item.ProductID;
                    dto.CategoryID = item.CategoryID;
                    dto.ProductName = item.productName;
                    dto.CategoryName = item.CategoryName;
                    dto.StockAmount = item.StockAmount;
                    dto.Price= item.Price;
                    products.Add(dto);
                }
                return products;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(PRODUCT entity)
        {
            try
            {
                PRODUCT product = db.PRODUCTs.First(x => x.ID == entity.ID);
                if (entity.CategoryID == 0)
                {
                    product.StockAmount = entity.StockAmount;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
