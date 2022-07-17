using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace CarMuayTahiSeguimiento.SQLite.DbModels
{
    public class MetodosPago
    {
        public int MedioPagoId { get; set; }
        public string MedioDescripcion { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<PagosPor15Clases> _PagosPor15Clases { get; set; }
    }
}
