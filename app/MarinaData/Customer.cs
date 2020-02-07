using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinaData
{
    /// <summary>
    /// object to represent customer table in marina database
    /// </summary>
    /// @author - harry
    public class Customer
    {
        // auto-implemented properties
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
    }
}
