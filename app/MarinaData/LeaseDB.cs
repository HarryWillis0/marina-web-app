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
    /// Operations on Lease table of Marina database
    /// </summary>
    /// @author - Chi 
    [DataObject(true)]
    public static class LeaseDB
    {
        /// <summary>
        /// Retrieve all slips from Slip Table in the database
        /// </summary>
        /// <returns>List of docks</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Lease> GetLease(int slipID)
        {
            List<Lease> leaselist = new List<Lease>(); // Empty list of Lease objects
            Lease lease; // For reading 

            // Each lease data returned, make Lease object and add to the list of Leases
            using (SqlConnection conn = MarinaDB.GetConnection())
            {
                // Create the command  for SELECT query to get the slips
                string query = "SELECT Slip.ID as 'SlipID', CustomerID, FirstName, LastName " +
                               "FROM Slip inner join Lease " +
                               "on Slip.ID = Lease.SlipID " +
                               "inner join Customer " +
                               "on Lease.CustomerID = Customer.ID " +
                               "WHERE Lease.SlipID = @slipID " +
                               "ORDER by SlipID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    // supply parameter value
                    cmd.Parameters.AddWithValue("@slipID", slipID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        lease = new Lease();
                        lease.SlipID = (int)reader["SlipID"];
                        lease.CustomerID = (int)reader["CustomerID"];
                        lease.FirstName = reader["FirstName"].ToString();
                        lease.LastName = reader["LastName"].ToString();
                        leaselist.Add(lease);
                    } // close reader
                } // close cmd
            } // close connection

            return leaselist;
        }
    }
}
