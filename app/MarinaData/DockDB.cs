using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinaData
{
    /// <summary>
    /// Operations on Dock table of Marina database
    /// </summary>
    /// @author - Chi 
    [DataObject(true)]
    public static class DockDB
    {
        /// <summary>
        /// Retrieve a list of docks from database
        /// </summary>
        /// <returns>List of docks</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Dock> GetDocks()
        {
            List<Dock> docks = new List<Dock>(); // Empty list of Dock objects
            Dock dock; // For reading 
            SqlConnection connection = MarinaDB.GetConnection();

            // Create the command  for SELECT query to get the docks
            string query = "SELECT [ID], [Name] " +
                           "FROM Dock " +
                           "ORDER by [Name]";

            // Each dock data returned, make dock object and add to the list docks
            using (SqlConnection conn = MarinaDB.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        dock = new Dock();
                        dock.DockID = (int)reader["ID"];
                        dock.DockName = reader["Name"].ToString();
                        docks.Add(dock);
                    } // close reader
                } // close cmd
            } // close connection

            return docks;
        }
    }
}
