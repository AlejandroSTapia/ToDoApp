using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
        }

        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                //construccion de obj item de tipo TodoItem
                var item = new ToDoItem
                {
                    //y asignacion de sus propiedades
                    //Donde Name es igual a la propiedad del model y nombre, id del campo del xaml
                    Name = nombre.Text,
                    Description = descripcion.Text
                };
                //esperamos resultado invocando a app.context(clase App.xaml) y
                //contexr es la conexion que establecimos alli
                //Y este context ya tiene al metodo InsertItem el cual recibe
                //un obj de  tipo todoItem
                var result = await App.Context.InsertItemAsync(item);

                //validacion, 1 guardado exitosamente
                if (result == 1)
                {
                    //Si si, regresara a la pagina anteriro y visaulizar el elemnto agregado con
                    await Navigation.PopAsync();
                }
                else
                {
                    //si no, un alert
                    await DisplayAlert("Error", "No se pudo guardar la tarea", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                //alerta
                await DisplayAlert("Error", ex.Message,"Aceptar");
            }
        }
    }
}