using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTacking.DAL.DAO
{
    internal interface IDAO<T,K> where T: class where K: class
    {
        //coleccion de objetos
        List<K> Select();
        //tipo de dato
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool GetBack(int ID);
    }
}
