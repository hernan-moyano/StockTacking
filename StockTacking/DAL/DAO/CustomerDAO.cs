using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTacking.DAL;
using StockTacking.DAL.DTO;

namespace StockTacking.DAL.DAO
{
    public class CustomerDAO : StockContext, IDAO<CUSTOMER, CustomerDetailDTO>
    {
        public bool Delete(CUSTOMER entity)
        {
            try
            {
                CUSTOMER customer = db.CUSTOMERs.First(x => x.ID == entity.ID);
                customer.isDeleted = true;
                customer.DeleteDate = DateTime.Today;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool GetBack(int ID)
        {
            try
            {
                CUSTOMER customer = db.CUSTOMERs.First(x => x.ID == ID);
                customer.isDeleted = false;
                customer.DeleteDate = null;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Insert(CUSTOMER entity)
        {
            try
            {
                db.CUSTOMERs.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<CustomerDetailDTO> Select()
        {
            try
            {
                List<CustomerDetailDTO> customers = new List<CustomerDetailDTO>();
                var list = db.CUSTOMERs.Where(x=>x.isDeleted == false).ToList();
                foreach ( var customer in list )
                {
                    CustomerDetailDTO dto = new CustomerDetailDTO();
                    dto.ID = customer.ID;
                    dto.CustomerName = customer.CustomerName;
                    customers.Add(dto);                    
                }
                return customers;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<CustomerDetailDTO> Select(bool isDeleted)
        {
            try
            {
                List<CustomerDetailDTO> customers = new List<CustomerDetailDTO>();
                var list = db.CUSTOMERs.Where(x => x.isDeleted == isDeleted).ToList();
                foreach (var customer in list)
                {
                    CustomerDetailDTO dto = new CustomerDetailDTO();
                    dto.ID = customer.ID;
                    dto.CustomerName = customer.CustomerName;
                    customers.Add(dto);
                }
                return customers;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public bool Update(CUSTOMER entity)
        {
            try
            {
                CUSTOMER customer = db.CUSTOMERs.First(x => x.ID == entity.ID);
                customer.CustomerName = entity.CustomerName;
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
