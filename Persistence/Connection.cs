using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Persistence
{
    public static class Connection
    {
        public static SqlConnection GetConection()
        {
            SqlConnection con = new SqlConnection("Server=localhost;Database=Concesionario;Integrated Security=True");
            return con;

        }
    }
}