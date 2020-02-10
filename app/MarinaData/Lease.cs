using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinaData
{
    /// <summary>
    /// Object to represent Slip table in Marina database
    /// </summary>
    /// @author - Chi
    public class Lease
    {
        // Auto-implemented properties
        public int SlipID { get; set; }
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Dock { get; set; }


    }
}
