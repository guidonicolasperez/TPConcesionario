using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class GetCustomerList : IGetCustomerList
    {
        // -- ATRIBUTOS -- 
        private readonly IDataBaseService _database;

        // -- CONTRUCTOR -- (Recibe los datos
        public GetCustomerList(IDataBaseService database)
        {
            _database = database;
        }


        // DEVUELVO LA LISTA DE CLIENTES
        public List<CustomerModel> Execute()
        {
            // 1 - CREO LA LISTA A DEVOLVER
            List<CustomerModel> listCustomerModel = new List<CustomerModel>();

            // 2 - TRAIGO LA LISTA DE CLIENTES DE LA BD.
            List<Customer> listCustomer = _database.Customers();

            // 3 - RECORRO LA LISTA Y CONVIERTO LOS clientes a clientes_Model
            foreach (var item in listCustomer)
            {
                CustomerModel cm = new CustomerModel(item.id, item.nombre, item.apellido);
                listCustomerModel.Add(cm);
            }

            // 4 - DEVUELVO LA LISTA
            return listCustomerModel;
        }
    }
}

