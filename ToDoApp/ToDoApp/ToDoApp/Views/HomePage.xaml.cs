using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        //Tener presente que al navegar otra pagina, una recomendacion es ejecutar un hilo u otro tipo de proceso para no bloquear la interf
        //Se conoce como proceso asincronico
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //await permite esperar y no bloquear nuestros procesos graficos de lo qeu se va a realizar
            // luego, con Navigation nos permite navegar o remover paginas y se necesita
            // vincular a una pestaña hacia el stack de nav preexistente mediante mtd pushasync
            await Navigation.PushAsync(new AddPage());
        }
    }
}