using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Application
{

    public class CRUDSale : ICRUDSale
    {

        // -- ATRIBUTOS --
        private readonly IDataBaseService _dataBase;

        // -- CONSTRUCTOR --
        public CRUDSale(IDataBaseService dataBase)
        {
            _dataBase = dataBase;
        }

        // -- METODOS --
        public bool newSaleModel(String idCustomer, int idCar, decimal salePrice)
        {
            return _dataBase.insertSale(idCustomer, idCar, salePrice);
        }

        public SaleModel getSale(int id)
        {
            string idSale = id.ToString();

            Sale mySale = _dataBase.sale(idSale);

            string idOfCar = mySale.idCar.ToString();

            Customer myCustomer = _dataBase.customer(mySale.idCustomer);
            Car myCar = _dataBase.car(idOfCar);

            CustomerModel customerModel = new CustomerModel(
                myCustomer.id,
                myCustomer.nombre,
                myCustomer.apellido);

            CarModel carModel = new CarModel(
                myCar.id,
                myCar.marca,
                myCar.modelo,
                myCar.precio);


            SaleModel saleModel = new SaleModel(
                customerModel,
                carModel,
                mySale.salePrice,
                DateTime.Now);

            return saleModel;


        }


        // Devuelve un listado de ventas
        public List<SaleModel> getAllSaleModel()
        {

            List<SaleModel> getAllSaleModel = new List<SaleModel>();

            List<Sale> sales = _dataBase.Sales();

           foreach (Sale mySale in sales)
            {
                string idOfCar = mySale.idCar.ToString();

                Console.WriteLine(idOfCar);


                Customer myCustomer = _dataBase.customer(mySale.idCustomer);
                Car myCar = _dataBase.car(idOfCar);

                CustomerModel customerModel = new CustomerModel(
                    myCustomer.id,
                    myCustomer.nombre,
                    myCustomer.apellido);

                CarModel carModel = new CarModel(
                    myCar.id,
                    myCar.marca,
                    myCar.modelo,
                    myCar.precio);


                SaleModel saleModel = new SaleModel(
                    mySale.id,
                    customerModel,
                    carModel,
                    mySale.salePrice,
                    DateTime.Now);

                getAllSaleModel.Add(saleModel);
            }

            return getAllSaleModel;

        }

    }

}
