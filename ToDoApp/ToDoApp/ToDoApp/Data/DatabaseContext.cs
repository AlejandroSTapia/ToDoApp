using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Models;

namespace ToDoApp.Data
{
    public class DatabaseContext
    {
        //primero creamos propiead de tipo sqlite
        public SQLiteAsyncConnection Connection { get; set; }
        //Constructor que recibira el path de la bd
        public DatabaseContext(string path)
        {
            //establecer la conexion y le enviamos la ruta de conexion
            Connection = new SQLiteAsyncConnection(path);

            //inicializar, construir o crear en caso que no existan, las dif tablas,
            //en este caso, la tabla de todoitem
            //Metodo async, esperar(con .Wait) su creacion antes de usarlo
            Connection.CreateTableAsync<ToDoItem>();
        }
    }
}
