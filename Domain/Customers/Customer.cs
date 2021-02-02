using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Customer : IEntity
    {
        public string id { set; get; }
        public string nombre { set; get; }
        public string apellido { set; get; }

        public Customer(string id, string nombre, string apellido)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public Customer(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public Customer(string id)
        {
            this.id = id;
        }



    }
}
