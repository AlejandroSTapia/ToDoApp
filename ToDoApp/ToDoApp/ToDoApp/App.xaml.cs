using System;
using ToDoApp.Data;
using ToDoApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp
{
    public partial class App : Application
    {

        //Iniciamos creando la propiedad  DatabaseCOntext para poder inicializar el cotexto de la BD
        //metodo static (paa poder acceder a ella dentro de todo el aplicativo) para inicializar la bd al inicar app
        public static DatabaseContext Context { get; set; }
        public App()
        {
            InitializeComponent();
            //INicializamos metdo
            InicializeDatabase();

            MainPage = new NavigationPage( new HomePage());
        }

        //metodo para inicializar la bd
        private void InicializeDatabase()
        {
            // obtenemos la carpta de la app y al folder donde estan los datos de la aplicacion local
            //ruta donde ira la bd
            var folderApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            //Tambien se ocupa la ruta de system de la ruta de folder app, sumando la bd(ToDo) y db3 es la extension de sqLite
            var dbPath = System.IO.Path.Combine(folderApp, "ToDo.db3");

            //Ya teneindo la ruta, vamos a inicializar la propiedad COntext establecida arriba
            //Y la inicializamos, enviando la ruta de la bd
            Context = new DatabaseContext(dbPath);
            //Con esto ya tenemos la inicializacion de nuestra BD y toda la configuracion necesaria para poder  utilizar BD locales
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
