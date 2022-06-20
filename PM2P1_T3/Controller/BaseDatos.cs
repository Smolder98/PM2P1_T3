using PM2P1_T3.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM2P1_T3.Controller
{
    public class BaseDatos
    {
        readonly SQLiteAsyncConnection dbase;
        public BaseDatos(string path)
        {
            dbase = new SQLiteAsyncConnection(path);

            dbase.CreateTableAsync<Persona>();
        }


        #region Persona
        //Metodos CRUD - CREATE
        public Task<int> insertUpdatePersona(Persona persona)
        {
            if (persona.id != 0)
            {
                return dbase.UpdateAsync(persona);
            }
            else
            {
                return dbase.InsertAsync(persona);
            }
        }

        //Metodos CRUD - READ
        public Task<List<Persona>> getListPersona()
        {
            return dbase.Table<Persona>().ToListAsync();
        }

        public Task<Persona> getPersona(int id)
        {
            return dbase.Table<Persona>()
                .Where(i => i.id == id)
                .FirstOrDefaultAsync();
        }

        //Metodos CRUD - DELETE
        public Task<int> deletePersona(Persona persona)
        {
            return dbase.DeleteAsync(persona);
        }

        #endregion Persona
    }
}
