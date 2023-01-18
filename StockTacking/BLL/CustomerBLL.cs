using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//para poder acceder a los datos
using StockTacking.DAL.DTO;
//para poder enviar información al DAO
using StockTacking.DAL.DAO;
using StockTacking.DAL;
//using StockTacking.BLL;
//using StockTacking.DAL;

namespace StockTacking.BLL
{
    public class CustomerBLL : IBLL<CustomerDetailDTO, CustomerDTO>
    {
        CustomerDAO dao = new CustomerDAO();

        public bool Delete(CustomerDetailDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool GetBack(int ID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(CustomerDetailDTO entity)
        {
            CUSTOMER customer = new CUSTOMER();
            customer.CustomerName = entity.CustomerName;
            return dao.Insert(customer);
        }

        public CustomerDTO Select()
        {
            CustomerDTO dto = new CustomerDTO();
            dto.Cutomers = dao.Select();
            return dto;
        }

        public bool Update(CustomerDetailDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
