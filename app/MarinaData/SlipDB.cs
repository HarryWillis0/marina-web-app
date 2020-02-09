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
    public static class SlipDB
    {
        /// <summary>
        /// Retrieve all slips from Slip Table in the database
        /// </summary>
        /// <returns>List of docks</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Slip> GetSlips(int Dock)
        {
            List<Slip> slips = new List<Slip>(); // Empty list of Slip objects
            Slip slip; // For reading 

            

            // Each dock data returned, make dock object and add to the list docks
            using (SqlConnection conn = MarinaDB.GetConnection())
            {
                // Create the command  for SELECT query to get the slips
                string query = "SELECT Slip.[ID], [Width], [Length], [Name] as 'DockName' " +
                               "FROM Slip inner join Dock " +
                               "on Slip.DockID = Dock.ID " +
                               "WHERE Slip.DockID = @Dock " +
                               "ORDER by [Name]";
                

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    // supply parameter value
                    cmd.Parameters.AddWithValue("@Dock", Dock);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        slip = new Slip();
                        slip.SlipID = (int)reader["ID"];
                        slip.Width = (int)reader["Width"];
                        slip.Length = (int)reader["Length"];
                        slip.Dock = reader["DockName"].ToString();
                        slips.Add(slip);
                    } // close reader
                } // close cmd
            } // close connection

            return slips;
        }
    }
}
