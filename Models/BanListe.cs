using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Banlist
    {
        public int Id { get; set; }
        public int Nom { get; set; }  // Correction du type a faire 
        public short Limitée { get; set; }
        public sbyte Interdite { get; set; }
    }
}
