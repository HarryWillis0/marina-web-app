using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MarinaData;
using System.Data.SqlClient;

namespace app.Models
{
    /// <summary>
    /// operations on default db
    /// </summary>
    public static class AppDB
    {
        /// <summary>
        /// Retrieve user by id
        /// </summary>
        /// <param name="id">id of user</param>
        /// <returns>user in Customer object</returns>
        public static Customer GetCustomerById(string id)
        {
            Customer customer = new Customer();
            string query = "SELECT FirstName, LastName, Phone, City " +
                           "FROM AspNetUsers " +
                           "WHERE Id = @id";
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            customer.FirstName = dr["FirstName"].ToString();
                            customer.LastName = dr["LastName"].ToString();
                            customer.Phone = dr["Phone"].ToString();
                            customer.City = dr["City"].ToString();
                        }
                    }
                }
            }
            return customer;
        }

        /// <summary>
        /// retrieve connection string from web.config
        /// </summary>
        /// <returns>connection string</returns>
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings
                ["DefaultConnection"].ConnectionString;
        }
    }
}