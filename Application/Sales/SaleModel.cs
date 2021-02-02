using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class SaleModel
    {
        public string id { get; set; }
        public CustomerModel customer { get; set; }
        public CarModel car { get; set; }
        public decimal salePrice { get; set; }
        public DateTime date { get; set; }


        public SaleModel(CustomerModel customer, CarModel car, decimal salePrice, DateTime date)
        {
            this.customer = customer;
            this.car = car;
            this.salePrice = salePrice;
            this.date = date;
        }

        public SaleModel(string id, CustomerModel customer, CarModel car, decimal salePrice, DateTime date)
        {
            this.id = id;
            this.customer = customer;
            this.car = car;
            this.salePrice = salePrice;
            this.date = date;
        }

        public SaleModel(string id)
        {
            this.id = id;
        }

        public string ToString()
        {
            return
                "Venta numero: " + this.id +
                "\nDatos del cliente: " +
                customer.ToString() +
                "\nVehiculo Vendido: " +
                car.ToString();
        }
    }
}
