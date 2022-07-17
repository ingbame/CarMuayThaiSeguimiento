using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace CarMuayTahiSeguimiento.SQLite.DbModels
{
    public class PagosPor15Clases
    {
        [PrimaryKey, AutoIncrement]
        public int PagosId { get; set; }
        public DateTime FechaPago { get; set; }
        [ForeignKey(typeof(MetodosPago))]
        public int MetodoPagoId { get; set; }
        public byte[] Evidencia { get; set; }

        [ManyToOne]
        public MetodosPago MetodoPago { get; set; }
    }
}
