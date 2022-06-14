using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities.Entities
{
    public class Articulo

    {
        [Key]
        public int IdArticulo { get; set; }
        public string Descripcion { get; set; }
        public string UnidadMedida { get; set; }
        public string CodigoBarra { get; set; }
        public int SaldoExistencia { get; set; }
        public string Estado { get; set; }
    }
}
