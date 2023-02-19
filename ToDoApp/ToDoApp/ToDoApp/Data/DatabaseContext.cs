using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Data
{
    //Clase para inicializar, configurar y acceder a la BD

    public class DatabaseContext
    {
        //primero creamos propiead de tipo sqliteasync
        private readonly SQLiteAsyncConnection Connection;

        //Constructor, donde recibira el path donde fisicamente sera almacenada la bd
        public DatabaseContext(string dbPath)
        {
            //establecer la conexion y le enviamos la ruta de conexion
            Connection = new SQLiteAsyncConnection(dbPath);

            //inicializar, construir o crear en caso que no existan, las dif tablas,
            //en este caso, la tabla de todoitem
            //Metodo async, esperar(con .Wait) su creacion antes de usarlo
            Connection.CreateTableAsync<ToDoItem>().Wait();
            //Luego de esto, ya teneindo el contexto de la bd, se debe inicializar en el momento que se abra el app, eso en App.xaml.cs e iniciamos creando la propiedad databaseContext
        }

        //Metodo para guardar un obj de tipo todoItem en bd
        //mtd que retorna un 1 si fue almacenado correctamente
        //mtd llamado INsert.. y recibimos un obj de tipo todoitem llamado item
        public async Task<int> InsertItemAsync(ToDoItem item)
        {
            //La implementacion del mtd sera un retorno en caso de que la conexion 
            //.insertasync, recibiendo el item especifico pueda hacer el guardado de la info
            return await Connection.InsertAsync(item);
        }
    }
}
