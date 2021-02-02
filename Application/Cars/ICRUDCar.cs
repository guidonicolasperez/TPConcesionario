using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application

{
    public interface ICRUDCar
    {
        bool newCarModel(string marca, string modelo, decimal precio);
        CarModel get(int id);
        List<CarModel> getAllCars();
    }
}
