using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    public class Sale : IEntity
    {
        public string id { get; set; }
        public string idCustomer { get; set; }
        public int idCar { get; set; }
        public decimal salePrice { get; set; }
        public DateTime date { get; set; }


        public Sale(string idCustomer, int idCar, decimal salePrice, DateTime date)
        {
            this.idCustomer = idCustomer;
            this.idCar = idCar;
            this.salePrice = salePrice;
            this.date = date;
        }

        public Sale(string id, string idCustomer, int idCar, decimal salePrice, DateTime date)
        {
            this.id = id;
            this.idCustomer = idCustomer;
            this.idCar = idCar;
            this.salePrice = salePrice;
            this.date = date;
        }

        public Sale(string id)
        {
            this.id = id;
        }
    }
}
