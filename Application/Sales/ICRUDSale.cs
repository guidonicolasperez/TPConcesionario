using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ICRUDSale
    {
        bool newSaleModel(String idCustomer, int idCar, decimal salePrice);
        SaleModel getSale(int id);
        List<SaleModel> getAllSaleModel();
    }
}
