using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application
{
    public interface IDataBaseService
    {

        // CUSTOMER
        bool insertCustomer(string id, string nombre, string apellido);
        Customer customer(string id);
        List<Customer> Customers();


        // CARS 
        bool insertCar(string marca, string modelo, decimal precio);
        Car car(string id);
        List<Car> Cars();

        // SALES
        bool insertSale(string idCustomer, int idCar, decimal salePrice);
        Sale sale(string id);
        List<Sale> Sales();

    }
}
