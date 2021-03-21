using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportExercise
{
    public class ProcEventArgs : EventArgs
    {
        public string ProcKey { get; set; }
        public int SelectRequestId { get; set; }
    }
}
