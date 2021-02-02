using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence;
using Application;
// BORRAR PARA ABAJO
using Domain;
using System.IO;
using System.Collections;

namespace TestConcesionario
{
    public class Program
    {
        public static CRUDCar carManager = new CRUDCar(new DataBaseServices());
        public static CRUDCustomer customerManager = new CRUDCustomer(new DataBaseServices());
        public static CRUDSale saleManager = new CRUDSale(new DataBaseServices());
        public static CRUDSale localSaleManeger = new CRUDSale(new CSVServices());

        public static void Main(string[] args)
        {
            string options = "Ingrese la operacion: \n 1.Ver todos los autos. \n 2.Agregar nuevo vehiculo. \n 3.Mostrar todos los clientes. \n 4.Agregar cliente. \n 5.Cargar venta. \n 6.Mostrar todas las ventas. \n 7.Mostrar las ventas locales \n 0.Salir \n";
            int response;

            response = getChoice(1, 8, options);

            while (response != 0)
            {
                switch (response)
                {
                    // 1.Ver todos los autos.
                    case 1:
                        showAllCars();
                        Console.WriteLine(" - - - - - - - - - - ");
                        break;

                    // 2.Agregar nuevo vehiculo.
                    case 2:
                        addNewCar();
                        Console.WriteLine(" - - - - - - - - - - ");
                        break;

                    // 3. Mostrar todos los clientes.
                    case 3:
                        showAllCustomers();
                        Console.WriteLine(" - - - - - - - - - - ");
                        break;

                    // 4. Agregar clientes
                    case 4:
                        addNewCustomer();
                        Console.WriteLine(" - - - - - - - - - - ");
                        break;

                    // 5.Cargar venta.
                    case 5:
                        addNewSale();
                        Console.WriteLine(" - - - - - - - - - - ");
                        break;


                    // 6.Mostrar todas las ventas.
                    case 6:
                        showAllSale();
                        Console.WriteLine(" - - - - - - - - - - ");
                        break;

                    //7.Exportar STOCK a.CSV
                    case 7:
                        ShowAllLocalSales();
                        Console.WriteLine(" - - - - - - - - - - ");
                        break;

                    // 8.Leer STOCK desde.CSV

                   

                    default:
                        break;
                }
                response = getChoice(1, 8, options);
            }

            
        }



        // -- ESTE METODO RECIVE LA CANT DE OPCIONES Y MENSAJE DE OPCIONES Y DEVUELVE EL NUMERO ELEGIDO
        public static int getChoice(int minChoice, int maxChoice, String text)
        {

            int i = -1; // VARIABLE AUX

            while ((i < minChoice || i > maxChoice) && i != 0)
            {
                Console.WriteLine(text);

                try
                {
                    Console.WriteLine("Num: ");
                    i = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(" - - - - - - - - - - ");

                    if ((i < minChoice || i > maxChoice) && i != 0)
                    {
                        Console.WriteLine(" - - - - - - - - - - ");
                        Console.WriteLine("La operacion elegida no es correcta.");
                    }
                }

                catch (Exception E)
                {
                    Console.WriteLine(" - - - - - - - - - - ");
                    Console.WriteLine("La operacion elegida no es correcta.");
                }

            }
            return i;
        }


        // MUESTRA TODOS LOS AUTOS.
        public static void showAllCars()
        {

            List<CarModel> listOfCars = carManager.getAllCars();

            foreach (CarModel carModel in listOfCars)
            {
                Console.WriteLine(carModel.ToString());
            }
        }

        // AGREGA AUTO.
        public static void addNewCar()
        {
            bool successful = false;
            string marca, modelo, confirm;
            decimal precio;

            try
            {
                // SOLICITO DATOS
                Console.WriteLine("Ingrese la marca del vehiculo: ");
                marca = Console.ReadLine();

                Console.WriteLine("Ingrese el modelo: ");
                modelo = Console.ReadLine();

                Console.WriteLine("Ingrese el precio: ");
                precio = decimal.Parse(Console.ReadLine());

                // CONFIRMO DATOS
                Console.WriteLine("¿Desea agregar el vehiculo " + marca + " " + modelo +
                    " con un precio de: $" + precio + " ? SI / NO");
                confirm = Console.ReadLine().Trim().ToLower();

                // SI CONFIRMA
                if (confirm.Equals("si"))
                {
                    // AGREGA EL MODELO Y MUESTRA POR PANTALLA QUE SE AGREGO
                    successful = carManager.newCarModel(marca, modelo, precio);
                    if (successful)
                    {
                        Console.WriteLine("Se agrego " + marca + " " + modelo + " con un precio de: $" + precio + ".");
                    }
                    else
                    {
                        Console.WriteLine("Error al cargar el cliente");

                    }
                }

            } // SI FALLA ALGO MUESTRA ERROR
            catch (Exception e)
            {
                Console.WriteLine("Error al cargar el modelo del vehiculo");
            }
        }

        // MUESTRA TODOS LOS CLIENTES.
        public static void showAllCustomers()
        {

            List<CustomerModel> listOfCustomers = customerManager.getAllCustomerModel();

            foreach (CustomerModel customerModel in listOfCustomers)
            {
                Console.WriteLine(customerModel.ToString());
            }
        }

        // AGREGA CLIENTE.
        public static void addNewCustomer()
        {
            bool successful = false;
            string dni, nombre, apellido, confirm;

            try
            {
                // SOLICITO DATOS
                Console.WriteLine("Ingrese el DNI del cliente: ");
                dni = Console.ReadLine();

                Console.WriteLine("Ingrese el nombre: ");
                nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el apellido: ");
                apellido = Console.ReadLine();

                // CONFIRMO DATOS
                Console.WriteLine("¿Desea agregar el cliente " + nombre + " " + apellido +
                    ", DNI:" + dni + " ? SI / NO");
                confirm = Console.ReadLine().Trim().ToLower();

                // SI CONFIRMA
                if (confirm.Equals("si"))
                {
                    // AGREGA EL MODELO Y MUESTRA POR PANTALLA QUE SE AGREGO
                    successful = customerManager.newCustomerModel(dni, nombre, apellido);
                    if (successful)
                    {
                        Console.WriteLine("Se agrego el cliente " + nombre + " " + apellido + ", DNI: " + dni + ".");
                    }
                    else
                    {
                        Console.WriteLine("Error al cargar el cliente");

                    }
                }

            } // SI FALLA ALGO MUESTRA ERROR
            catch (Exception e)
            {
                Console.WriteLine("Error al cargar el cliente.");
            }
        }

        // MUESTRA TODAS LAS VENTAS.
        public static void showAllSale()
        {
            List<SaleModel> listOfSales = saleManager.getAllSaleModel();

            foreach (SaleModel saleModel in listOfSales)
            {
                Console.WriteLine(saleModel.ToString());
            }
        }

        // AGREGA VENTA.

        public static void addNewSale()
        {
            bool successful = false;
            bool successfullLocal = false;
            string dni, idCar, response;
            CarModel carModel;
            decimal salePrice;


            // 1 - SOLICITO DNI
            Console.WriteLine("Ingrese el DNI del cliente: ");
            dni = Console.ReadLine();

            while(customerManager.getCustomerModel(dni) == null)
            {
                Console.WriteLine("Ingrese el DNI del cliente: ");
                dni = Console.ReadLine();
            }


            // 2 - MUESTROS LOS AUTOS Y SOLICITO EL ID DEL AUTO.
            showAllCars();

            Console.WriteLine("Ingrese el id del vehiculo: ");
            idCar = Console.ReadLine();

            //  Traigo el auto
            carModel = carManager.get(Int32.Parse(idCar));


            // 3 - MUESTRO EL PRECIO DE LISTA Y SOLICITO EL DE VENTA
            Console.WriteLine("El precio de lista sugerido es de: $" + carModel.precio +
                ".\nIngrese el precio de venta:");
            salePrice = decimal.Parse(Console.ReadLine());


            // 4 - AGREGO LA VENTA
            saleManager.newSaleModel(dni, (Int32.Parse(idCar)), salePrice);

            // 5 - Pregunto si quiero guarda la venta localmente.

            Console.WriteLine("¿Desea guardar la venta de manera local? SI/NO");
            response = Console.ReadLine().Trim().ToLower();

            if (response.Equals("si"))
            {
                successfullLocal = localSaleManeger.newSaleModel(dni, Int32.Parse(idCar), salePrice);
            }

            if (successfullLocal)
            {
                Console.WriteLine("Se guardo la venta de manera local");
            }
            else
            {
                Console.WriteLine("No se pudeo guarda la venta localmente.");
            }
        }

        public static void ShowAllLocalSales()
        {
            List<SaleModel> listOfSales = localSaleManeger.getAllSaleModel();

            foreach (SaleModel saleModel in listOfSales)
            {
                Console.WriteLine(saleModel.ToString());
            }
        }

    }
}
