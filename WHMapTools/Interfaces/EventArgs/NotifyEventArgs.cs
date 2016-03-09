using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHMapTools.Interfaces
{
    public class NotifyEventArgs
    {
        public int Layer { get; set; }
        public byte[,] Map { get; set; } 
    }
}
