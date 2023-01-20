﻿using System;
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
            throw new NotImplementedException();
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
                var list = (from s in db.SALES
                            join p in db.PRODUCTs on s.ProductID equals p.ID
                            join c in db.CUSTOMERs on s.CustomerID equals c.ID
                            join cat in db.CATEGORies on s.CategoryID equals cat.ID
                            select new{
                            productname = p.ProductName,
                            customername = c.CustomerName,
                            categoryname = cat.CategoryName,
                            productID= s.ProductID,
                            customerID = s.CustomerID,
                            salesID = s.ID,
                            categoryID= s.CategoryID,
                            salesprice = s.ProductSalesPrice,
                            salesamoun= s.ProductSalesAmount,
                            salesdate=s.SalesDate
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
                    dto.SalesAmount = item.salesamoun;
                    dto.SalesDate = item.salesdate;
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
            throw new NotImplementedException();
        }
    }
}
