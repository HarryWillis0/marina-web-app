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
        public static List<Lease> GetUserLease(string userName)
        {
            List<Lease> leaselist = new List<Lease>(); // Empty list of Lease objects
            Lease lease; // For reading 

            // Each lease data returned, make Lease object and add to the list of Leases
            using (SqlConnection conn = MarinaDB.GetConnection())
            {
                // Create the command  for SELECT query to get the slips
                string query = "SELECT Slip.ID as 'SlipID', CustomerID, FirstName, LastName, Email, Dock.[Name] as 'Dock' " +
                               "FROM Customer inner join Lease " +
                                    "on  Customer.ID = Lease.CustomerID " +
                               "inner join Slip " +
                                    "on Lease.SlipID = Slip.ID " +
                               "INNER JOIN dock " +
                                    "on Slip.DockID = dock.ID " +
                               "WHERE Customer.Email = @userName " +
                               "ORDER by SlipID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    // supply parameter value
                    cmd.Parameters.AddWithValue("@userName", userName);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        lease = new Lease();
                        lease.SlipID = (int)reader["SlipID"];
                        lease.CustomerID = (int)reader["CustomerID"];
                        lease.FirstName = reader["FirstName"].ToString();
                        lease.LastName = reader["LastName"].ToString();
                        lease.Email = reader["Email"].ToString();
                        lease.Dock = reader["Dock"].ToString();
                        leaselist.Add(lease);
                    } // close reader
                } // close cmd
            } // close connection

            return leaselist;
        }

        /// <summary>
        /// Inserts a lease into the database
        /// </summary>
        /// <param name="userID">Customer ID to add to lease.</param>
        /// <param name="slipID">Slip ID to add to lease.</param>
        public static void InsertLease(int userID, int slipID)
        {
            string insert = "INSERT INTO Lease " +
                            "(SlipID, CustomerID) " +
                            "VALUES (@SlipID, @CustomerID)";
            using (SqlConnection conn = MarinaDB.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(insert, conn))
                {
                    conn.Open();
                    // add parameters to query
                    cmd.Parameters.AddWithValue("@SlipID", slipID);
                    cmd.Parameters.AddWithValue("@CustomerID", userID);
                    cmd.ExecuteNonQuery();
                } // close cmd
            } // close connection
        }
    }
}
