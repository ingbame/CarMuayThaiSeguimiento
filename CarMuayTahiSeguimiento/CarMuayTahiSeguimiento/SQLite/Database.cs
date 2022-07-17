using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarMuayTahiSeguimiento.SQLite.DbModels;
using SQLite;

namespace CarMuayTahiSeguimiento.SQLite
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _connection;
        public Database(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<MetodosPago>();
            MetodosPago metodoPagoIns = new MetodosPago
            {
                MedioDescripcion = "Transferencia"
            };
            var metodo = _connection.InsertAsync(metodoPagoIns);
            
            metodoPagoIns = new MetodosPago
            {
                MedioDescripcion = "Efectivo"
            };
            metodo = _connection.InsertAsync(metodoPagoIns);
            _connection.CreateTableAsync<PagosPor15Clases>();
        }
        public Task<List<PagosPor15Clases>> GetPagosPor15ClasesAsync()
        {
            return _connection.Table<PagosPor15Clases>().ToListAsync();
        }
        public Task<int> SavePagosPor15ClasesAsync(PagosPor15Clases PagoPor15Clases)
        {
            return _connection.InsertAsync(PagoPor15Clases);
        }
    }
}
