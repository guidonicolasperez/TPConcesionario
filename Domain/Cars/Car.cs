using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Car : IEntity
    {
        public string id { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public decimal precio { get; set; }

        public Car(string marca, string modelo, decimal precio)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.precio = precio;  
        }

        public Car(string id, string marca, string modelo, decimal precio)
        {
            this.id = id;
            this.marca = marca;
            this.modelo = modelo;
            this.precio = precio;
        }

        public Car(string id)
        {
            this.id = id;
        }

    }
}
