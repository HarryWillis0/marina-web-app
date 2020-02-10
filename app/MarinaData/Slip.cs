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
    public class Slip
    {
        // Auto-implemented properties
        public int SlipID { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public string Dock { get; set; }
    }
}
