using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTacking.DAL;
using StockTacking.DAL.DTO;

namespace StockTacking.DAL.DAO
{
    public class SalesDAO : StockContext, IDAO<SALE, SalesDetailDTO>
    {
        public bool Delete(SALE entity)
        {
            try
            {   //AL ELIMINAR UNA VENTA
                if (entity.ID != 0)
                {
                    SALE sales = db.SALES.First(x => x.ID == entity.ID);
                    //si se desea borrar realmente de la base de datos seria lo siguiente:
                    //db.SALES.Remove(sales);
                    //db.SaveChanges();
                    //en éste caso solo se cancela la venta
                    sales.isDeleted = true;
                    sales.DeletedDate = DateTime.Now;
                    db.SaveChanges();
                }
                //AL ELIMINAR UN PRODUCTO
                else if (entity.ProductID!=0)
                {
                    List<SALE> sales = db.SALES.Where(x=>x.ProductID==entity.ProductID).ToList();
                    foreach (var item in sales)
                    {
                        item.isDeleted = true;
                        item.DeletedDate = DateTime.Now;
                    }
                    db.SaveChanges();
                }
                //AL ELIMINAR UN CLIENTE
                else if (entity.CustomerID != 0)
                {
                    List<SALE> sales = db.SALES.Where(x => x.CustomerID == entity.CustomerID).ToList();
                    foreach (var item in sales)
                    {
                        item.isDeleted = true;
                        item.DeletedDate = DateTime.Now;
                    }
                    db.SaveChanges();
                }
                //AL ELIMINAR UNA CATEGORÍA
                //else if (entity.CategoryID != 0)
                //{
                //    List<SALE> sales = db.SALES.Where(x => x.CategoryID == entity.CategoryID).ToList();
                //    foreach (var item in sales)
                //    {
                //        item.isDeleted = true;
                //        item.DeletedDate = DateTime.Now;
                //    }
                //    db.SaveChanges();
                //}
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(SALE entity)
        {
            try
            {
                db.SALES.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<SalesDetailDTO> Select()
        {
            try
            {
                List<SalesDetailDTO> sales = new List<SalesDetailDTO>();
                var list = (from s in db.SALES.Where(x=>x.isDeleted == false)
                            join p in db.PRODUCTs on s.ProductID equals p.ID
                            join c in db.CUSTOMERs on s.CustomerID equals c.ID
                            join cat in db.CATEGORies on s.CategoryID equals cat.ID
                            select new
                            {                                
                                productname = p.ProductName,
                                customername = c.CustomerName,
                                categoryname = cat.CategoryName,
                                productID = s.ProductID,
                                customerID = s.CustomerID,
                                salesID = s.ID,
                                categoryID = s.CategoryID,
                                salesprice = s.ProductSalesPrice,
                                salesamount = s.ProductSalesAmount,
                                stockamount = p.StockAmount,
                                salesdate = s.SalesDate
                            }).OrderByDescending(x => x.salesdate).ToList();
                foreach (var item in list)
                {
                    SalesDetailDTO dto = new SalesDetailDTO();
                    dto.ProductName = item.productname;
                    dto.CustomerName = item.customername;
                    dto.CategoryName = item.categoryname;
                    dto.ProductID = item.productID;
                    dto.CustomerID = item.customerID;
                    dto.SalesID = item.salesID;
                    dto.CategoryID = item.categoryID;
                    dto.Price = item.salesprice;
                    dto.SalesAmount = item.salesamount;
                    dto.SalesDate = item.salesdate;
                    dto.StockAmount = item.stockamount;
                    sales.Add(dto);
                }
                return sales;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(SALE entity)
        {
            try
            {
                SALE sales = db.SALES.First(x => x.ID == entity.ID);
                sales.ProductSalesAmount = entity.ProductSalesAmount;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
