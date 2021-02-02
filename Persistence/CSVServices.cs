using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Collections;
using Domain;
using Application;

namespace Persistence
{
    public class CSVServices : IDataBaseService
    {


        public Car car(string idCar)
        {
            DataBaseServices DBS = new DataBaseServices();
            return DBS.car(idCar);
        }

        public List<Car> Cars()
        {
            throw new NotImplementedException();
        }

        public Customer customer(string id)
        {
            DataBaseServices DBS = new DataBaseServices();
            Customer customer = DBS.customer(id);
            return customer;
        }

        public List<Customer> Customers()
        {
            throw new NotImplementedException();
        }

        public bool insertCar(string marca, string modelo, decimal precio)
        {

            return false;
        }

        public bool insertCustomer(string id, string nombre, string apellido)
        {
            return false;
        }


        // SALES 
        public bool insertSale(string idCustomer, int idCar, decimal salePrice)
        {
            bool ok = false;

            string fileLine;
            int maxId = 0;

            List<string> linesOfFile = new List<string>();


            try
            {
                // Levanto el archivo
                StreamReader streamReader = new StreamReader("D:\\Data\\Cars.txt");

                // Leo la primer linea
                fileLine = streamReader.ReadLine();

                // Mientras la linea no sea null
                while (fileLine != null)
                {

                    if (fileLine.Contains(';'))
                    {
                        // Agrego la linea.
                        linesOfFile.Add(fileLine);

                        // Guardo el id mas alto.
                        String[] car = fileLine.Split(';');
                        maxId = Convert.ToInt32(car[0]);
                    }

                    // Leo la proxima linea.
                    fileLine = streamReader.ReadLine();
                }

                streamReader.Close();

            }
            catch (Exception e)
            {
                ok = false;
            }

            maxId++;

            linesOfFile.Add(maxId + ";" + idCustomer + ";" + idCar + ";" + salePrice + ";" + DateTime.Now.ToString("dd/MM/yyyy"));

            try
            {

                StreamWriter streamWriter = new StreamWriter("D:\\Data\\Cars.txt");

                // escribo las lineas
                foreach (string line in linesOfFile)
                {
                    streamWriter.WriteLine(line);
                }

                streamWriter.Close();

                ok = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ok = false;
            }

            return ok;
        }

        public Sale sale(string id)
        {

            string fileLine;
            Sale sale = null;

            try
            {
                // Levanto el archivo
                StreamReader streamReader = new StreamReader("D:\\Data\\Cars.txt");

                // Leo la primer linea
                fileLine = streamReader.ReadLine();

                // Mientras la linea no sea null
                while (fileLine != null)
                {

                    // Verifico que la linea sea del tipo csv.
                    if (fileLine.Contains(';'))
                    {
                        // LEO LA LINEA
                        String[] car = fileLine.Split(';');

                        if (car[0].Equals(id))
                        {

                            String[] dateTime = car[4].Split('/');

                            sale = new Sale(car[0]);
                            sale.idCustomer = car[1];
                            sale.idCar = Int32.Parse(car[2]);
                            sale.salePrice = Decimal.Parse(car[3]);

                            sale.date = new DateTime(Int32.Parse(dateTime[2]), Int32.Parse(dateTime[1]), Int32.Parse(dateTime[0]));


                        }
                    }


                    // Leo la proxima linea.
                    fileLine = streamReader.ReadLine();
                }

                streamReader.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

            return sale;
        }

        public List<Sale> Sales()
        {
            string fileLine;
            int maxId = 0;

            Sale sale;
            List<Sale> sales = new List<Sale>();

            try
            {
                // Levanto el archivo
                StreamReader streamReader = new StreamReader("D:\\Data\\Cars.txt");

                // Leo la primer linea
                fileLine = streamReader.ReadLine();

                // Mientras la linea no sea null
                while (fileLine != null)
                {


                    if (fileLine.Contains(';'))
                    {
                        // Guardo el id mas alto.
                        String[] car = fileLine.Split(';');
                        String[] dateTime = car[4].Split('/');

                        sale = new Sale(car[0]);
                        sale.idCustomer = car[1];
                        sale.idCar = Int32.Parse(car[2]);
                        sale.salePrice = Decimal.Parse(car[3]);

                        sale.date = new DateTime(Int32.Parse(dateTime[2]), Int32.Parse(dateTime[1]), Int32.Parse(dateTime[0]));

                        sales.Add(sale);

                    }


                    // Leo la proxima linea.
                    fileLine = streamReader.ReadLine();
                }

                streamReader.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }


            return sales;

        }


    }
}
