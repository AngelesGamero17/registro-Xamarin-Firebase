using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aplicacionmovil.Views.Trabajadores
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrabajadoresEntry1 : ContentPage
    {
        TrabajadoresRepositorio repositorio = new TrabajadoresRepositorio();
        public TrabajadoresEntry1()
        {
            InitializeComponent();
        }

        private async void ButtonSave_Clicked(object sender, EventArgs e)
        {
            string nombres = nombre.Text;
            string descripciones = descripcion.Text;
            string DNIS = DNI.Text;
            string Celulares = Celular.Text;
            string Direcciones = Direccion.Text;
            string Correos = Correo.Text;
            if (string.IsNullOrEmpty(nombres) ) 
            {
                await DisplayAlert("Warning", "Porfavor ingrese su nombre", "cancel");
            }
            if (string.IsNullOrEmpty(descripciones))
            {
                await DisplayAlert("Warning", "Porfavor ingrese su apellido", "cancel");
            }
            if (string.IsNullOrEmpty(DNIS))
            {
                await DisplayAlert("Warning", "Porfavor ingrese su DNI", "cancel");
            }

            if (string.IsNullOrEmpty(Celulares))
            {
                await DisplayAlert("Warning", "Porfavor ingrese su celular", "cancel");
            }

            if (string.IsNullOrEmpty(Direcciones))
            {
                await DisplayAlert("Warning", "Please enter your direccion", "cancel");
            }

            if (string.IsNullOrEmpty(Correos))
            {
                await DisplayAlert("Warning", "Please enter your correo", "cancel");
            }



            Trabajador trabajador = new Trabajador();
            trabajador.Nombre = nombres;
            trabajador.Description = descripciones;
            trabajador.DNI = DNIS;
            trabajador.Celular = Celulares;
            trabajador.Direccion = Direcciones;
            trabajador.Correo = Correos;

            var isSaved = await repositorio.Save(trabajador);
            if (isSaved) 
            {
                await DisplayAlert("Informacion", "Se Guardo     Correctamente", "ok");
                Clear();
            }
            else
            {
                await DisplayAlert("Error", "Trabajadores saved falied", "ok");
                Clear();
            }
        }
        public void Clear()
        {
           nombre.Text = string.Empty;
           descripcion.Text = string.Empty;
           DNI.Text = string.Empty;
           Celular.Text = string.Empty;
           Direccion.Text = string.Empty;
           Correo.Text = string.Empty;
        }
    }
}