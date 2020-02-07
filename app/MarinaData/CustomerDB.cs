using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinaData
{
    /// <summary>
    /// operations on customer table of marina database
    /// </summary>
    /// @author - Harry 
    public static class CustomerDB
    {
        /// <summary>
        /// Retrieve all customers from database
        /// </summary>
        /// <returns>List of customers</returns>
        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            string query = "SELECT ID, FirstName, LastName, Phone, City " +
                           "FROM Customer " +
                           "ORDER BY ID";

            using (SqlConnection conn = MarinaDB.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    Customer curr;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        curr = new Customer();
                        curr.ID = (int)reader["ID"];
                        curr.FirstName = reader["FirstName"].ToString();
                        curr.LastName = reader["LastName"].ToString();
                        curr.Phone = reader["Phone"].ToString();
                        curr.City = reader["City"].ToString();
                        customers.Add(curr);
                    } // close reader
                } // close cmd
            } // close connection
                return customers;
        }

        /// <summary>
        /// inserts a new customer into the database
        /// </summary>
        /// <param name="newCustomer">customer to add</param>
        public static void Insert(Customer newCustomer)
        {
            string insert = "INSERT INTO Customer " +
                            "(FirstName, LastName, Phone, City) " +
                            "VALUES (@FirstName, @LastName, @Phone, @City)";
            using (SqlConnection conn = MarinaDB.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(insert, conn))
                {
                    conn.Open();
                    // add parameters to query
                    cmd.Parameters.AddWithValue("@FirstName", newCustomer.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", newCustomer.LastName);
                    cmd.Parameters.AddWithValue("@Phone", newCustomer.Phone);
                    cmd.Parameters.AddWithValue("@City", newCustomer.City);
                    cmd.ExecuteNonQuery();
                } // close cmd
            } // close connection
        }
    }
}
