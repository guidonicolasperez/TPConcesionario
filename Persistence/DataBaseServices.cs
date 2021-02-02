using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.SqlClient;

namespace Persistence
{
    public class DataBaseServices : IDataBaseService
    {

        // -- CUSTOMERS --
        public bool insertCustomer(string id, string nombre, string apellido)
        {
            bool ok = false;
            SqlConnection sqlConnection = Connection.getConection();

            SqlCommand sqlCommand = new SqlCommand(
                "INSERT INTO CUSTOMERS VALUES ('" + id + "','" + nombre + "','" + apellido + "')"
                , sqlConnection);

            try
            {
                int filasAfectadas;
                sqlConnection.Open();
                filasAfectadas = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                if (filasAfectadas >= 1)
                {
                    ok = true;
                }
            }
            catch (Exception e)
            {
            }

            return ok;
        }
        public Customer customer(string id)
        {
            SqlConnection sqlConnection = Connection.getConection();

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM CUSTOMERS WHERE id = '" + id + "'", sqlConnection);

            sqlConnection.Open();

            try
            {
                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                dataReader.Read();

                Customer customer = new Customer((string)dataReader["id"]);
                customer.nombre = (string)dataReader["nombre"];
                customer.apellido = (string)dataReader["apellido"];

                return customer;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }

        }
        public List<Customer> Customers()
        {
            // CREO LA LISTA QUE VOY A DEVOLVER
            List<Customer> customers = new List<Customer>();

            // 1 - Creo una conexion con la cadena al servidor.
            SqlConnection SqlCon = Connection.getConection();

            // 2 - CREO UN SQLCOMMAND CON LA QUERY, ABRO LA CONEXION Y EJECUTO
            SqlCommand command = new SqlCommand("SELECT * FROM CUSTOMERS", SqlCon);
            SqlCon.Open();

            try
            {
                SqlDataReader dataReader = command.ExecuteReader();

                // 3 - RECORRO EL DATAREADER, creo un cliente y lo meto al list.
                while (dataReader.Read())
                {
                    Customer customer = new Customer(
                        (string)dataReader["id"],
                        (string)dataReader["nombre"],
                        (string)dataReader["apellido"]);

                    customers.Add(customer);
                }
                return customers;

            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                // 4. CIERRO LA CONEXION Y DEVUELVO EL LIST
                SqlCon.Close();

            }

        }


        // -- CARS -- 
        public bool insertCar(string marca, string modelo, decimal precio)
        {
            bool ok = false;
            SqlConnection sqlConnection = Connection.getConection();

            SqlCommand sqlCommand = new SqlCommand(
                "INSERT INTO CARS VALUES ('" + marca + "','" + modelo + "','" + precio + "')"
                , sqlConnection);

            try
            {
                int filasAfectadas;
                sqlConnection.Open();
                filasAfectadas = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                if (filasAfectadas >= 1)
                {
                    ok = true;
                }


            }
            catch (Exception e)
            {
            }

            return ok;
        }
        public Car car(string id)
        {
            SqlConnection sqlConnection = Connection.getConection();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM CARS WHERE id = '" + id + "'", sqlConnection);

            sqlConnection.Open();

            try
            {
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();

                int idCar = (int)dataReader["id"];
                Car car = new Car(
                    idCar.ToString(),
                    (string)dataReader["marca"],
                    (string)dataReader["modelo"],
                    (decimal)dataReader["precio"]);

                return car;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();

                return null;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public List<Car> Cars()
        {
            List<Car> cars = new List<Car>();

            SqlConnection SqlCon = Connection.getConection();
            SqlCommand command = new SqlCommand("SELECT * FROM CARS", SqlCon);

            SqlCon.Open();

            try
            {
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Car car = new Car(((int)dataReader["id"]).ToString());

                    car.marca = (string)dataReader["marca"];
                    car.modelo = (string)dataReader["modelo"];
                    car.precio = (decimal)dataReader["precio"];

                    cars.Add(car);
                }

                return cars;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                SqlCon.Close();
            }

        }



        // -- SALES --
        public bool insertSale(string idCustomer, int idCar, decimal salePrice)
        {
            bool ok = false;
            SqlConnection sqlConnection = Connection.getConection();
            DateTime time = DateTime.Now;

            SqlCommand sqlCommand = new SqlCommand(
                "INSERT INTO SALES VALUES ('" + idCustomer + "','" + idCar + "'," + salePrice + ",'" + time + "')"
                , sqlConnection);

            try
            {
                int filasAfectadas;
                sqlConnection.Open();
                filasAfectadas = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                if (filasAfectadas >= 1)
                {
                    ok = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }

            return ok;
        }

        public Sale sale(string id)
        {
            SqlConnection sqlConnection = Connection.getConection();

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM SALES WHERE id = '" + id + "'", sqlConnection);

            sqlConnection.Open();

            try
            {
                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                dataReader.Read();


                Sale sale = new Sale(
                    ((int)dataReader["id"]).ToString(),
                    (string)dataReader["idCustomer"],
                    (int)dataReader["idCar"],
                    (decimal)dataReader["salePrice"],
                    (DateTime)dataReader["fecha"]
                    );

                return sale;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                sqlConnection.Close();
            }

        }

        public List<Sale> Sales()
        {
            List<Sale> Sales = new List<Sale>();

            SqlConnection SqlCon = Connection.getConection();
            SqlCommand command = new SqlCommand("SELECT * FROM SALES", SqlCon);

            SqlCon.Open();

            try
            {
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Sale sale = new Sale(
                    ((int)dataReader["id"]).ToString(),
                    (string)dataReader["idCustomer"],
                    (int)dataReader["idCar"],
                    (decimal)dataReader["salePrice"],
                    (DateTime)dataReader["fecha"]
                    );

                    Sales.Add(sale);
                }

                return Sales;
            }
            catch (ArgumentNullException e)
            {
                return null;
            }
            finally
            {
                SqlCon.Close();
            }
        }















    }
}
