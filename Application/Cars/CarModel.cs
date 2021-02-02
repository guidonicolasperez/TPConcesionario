using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class CarModel
    {
        public string id { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public decimal precio { get; set; }

        public CarModel(string marca, string modelo, decimal precio)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.precio = precio;
        }

        public CarModel(string id, string marca, string modelo, decimal precio)
        {
            this.id = id;
            this.marca = marca;
            this.modelo = modelo;
            this.precio = precio;
        }

        public string ToString()
        {
            return
                "Id: " + id +
                " Marca: " + marca +
                " Modelo: " + modelo +
                " Precio: " + precio +
                ". ";
        }
    }
}
