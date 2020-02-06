using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinaData
{
    /// <summary>
    /// Connect to Marina database 
    /// </summary>
    public static class MarinaDB
    {
        /// <summary>
        /// Connect to Marina database
        /// </summary>
        /// <returns>Sql connection to Marina database</returns>
        /// @author harry 
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source = localhost\SQLEXPRESS; Initial Catalog = Marina; Integrated Security = True";

            return new SqlConnection(connectionString);
        }
    }
}
