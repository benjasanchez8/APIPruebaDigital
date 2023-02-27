using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.DTO
{
    public class ClienteDTO
    {

        public int IdCliente { get; set; }

        public string? Nombre { get; set; }

        public int? Edad { get; set; }

        public int? Telefono { get; set; }

        public string? Correo { get; set; }

        public int? EsActivo { get; set; }

       }
}
