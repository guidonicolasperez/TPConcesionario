using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;


namespace Application
{

    public class CRUDCustomer : ICRUDCustomer
    {
        // -- ATRIBUTOS -- 
        private readonly IDataBaseService _database;


        // -- CONSTRUCTORES --
        public CRUDCustomer(IDataBaseService database)
        {
            this._database = database;
        }


        // -- METODOS --
        public bool newCustomerModel(string id, string nombre, string apellido)
        {
            return _database.insertCustomer(id, nombre, apellido);
        }


        public CustomerModel getCustomerModel(string id)
        {
            Customer customer = _database.customer(id);

            try
            {
                return new CustomerModel(customer.id, customer.nombre, customer.apellido);
            } catch ( Exception e)
            {
                return null;
            }
            
        }


        public List<CustomerModel> getAllCustomerModel()
        {
            List<CustomerModel> getAllCustomerModel = new List<CustomerModel>();
            List<Customer> listCustomer = _database.Customers();

            foreach(Customer customer in listCustomer)
            {
                getAllCustomerModel.Add(new CustomerModel(customer.id, customer.nombre, customer.apellido));
            }

            return getAllCustomerModel;


        }


    }
}


