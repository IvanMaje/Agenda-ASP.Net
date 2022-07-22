using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Models
{
    public class Amigo
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public int NumeroTelefonico { get; set; }
        public int ListaAmigosId { get; set; }
    }
}
