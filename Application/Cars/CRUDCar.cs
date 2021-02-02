using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class CRUDCar : ICRUDCar
    {

        // -- ATRIBUTOS -- 
        private readonly IDataBaseService _database;

        // -- CONTRUCTOR -- (Recibe los datos)
        public CRUDCar(IDataBaseService database)
        {
            _database = database;
        }


        // -- METODOS --

        public bool newCarModel(string marca, string modelo, decimal precio)
        {
            return _database.insertCar(marca, modelo, precio);
        }


        public CarModel get(int id)
        {
            Car car = _database.car(id.ToString());

            if (car != null)
            {
                return new CarModel(car.id, car.marca, car.modelo, car.precio);
            }
            else
            {
                return null;
            }
           
        }

        public List<CarModel> getAllCars()
        {
            List<CarModel> carModels = new List<CarModel>();
            List<Car> cars = _database.Cars();

            foreach (Car car in cars)
            {
                carModels.Add(new CarModel(car.id, car.marca, car.modelo, car.precio));
            }
            return carModels;
        }

    }
}
