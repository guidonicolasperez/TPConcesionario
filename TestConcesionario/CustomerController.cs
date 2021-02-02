using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;

namespace TestConcesionario
{
    public class CustomersController
    {
        private readonly IGetCustomerList _query;
        public CustomersController(IGetCustomerList query)
        {
            _query = query;
        }

        public void render()
        {
            List<CustomerModel> customers = _query.Execute();
            foreach (var item in customers)
            {
                Console.WriteLine("Id: " + item.id + " Nombre Completo: " + item.nombre + item.apellido);
             
            }
        }


    }
}
