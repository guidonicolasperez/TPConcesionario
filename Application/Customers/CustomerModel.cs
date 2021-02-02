using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class CustomerModel
    {
        public string id { set; get; }
        public string nombre { set; get; }
        public string apellido { set; get; }

        public CustomerModel(string id, string nombre, string apellido)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public CustomerModel(string id)
        {
            this.id = id;
        }

                
        public string ToString()
        {
            return
                "DNI: " + id +
                " Nombre: " + nombre +
                " Apellido: " + apellido +
                ". ";
        }
    }
}
