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
	public partial class TrbajadoresEdit : ContentPage
	{
        TrabajadoresRepositorio trabajadoresRepositorio = new TrabajadoresRepositorio();
		internal TrbajadoresEdit (Trabajador trabajador)
		{
			InitializeComponent ();
			nombre.Text = trabajador.Nombre;
			descripcion.Text = trabajador.Description;
            DNI.Text = trabajador.DNI;
            Celular.Text = trabajador.Celular;
            Direccion.Text = trabajador.Direccion;
            Correo.Text = trabajador.Correo;
            TxtId.Text = trabajador.Id;
		}

        private async void ButtonUpdate_Clicked(object sender, EventArgs e)
        {
                string nombres = nombre.Text;
                string descripciones = descripcion.Text;
                string DNIS = DNI.Text;
                string Celulares = Celular.Text;
                string Direcciones = Direccion.Text;
                string Correos = Correo.Text;
            if (string.IsNullOrEmpty(nombres))
                {
                    await DisplayAlert("Warning", "Please enter your name", "ok");
                }
                if (string.IsNullOrEmpty(descripciones))
                {
                    await DisplayAlert("Warning", "Please enter your descripcion", "ok");
                    }
                if (string.IsNullOrEmpty(DNIS))
                {
                    await DisplayAlert("Warning", "Please enter your name", "ok");
                }
                if (string.IsNullOrEmpty(Celulares))
                {
                    await DisplayAlert("Warning", "Please enter your descripcion", "ok");
                }
                if (string.IsNullOrEmpty(Direcciones))
                {
                    await DisplayAlert("Warning", "Please enter your name", "ok");
                }
                if (string.IsNullOrEmpty(Correos))
                {
                    await DisplayAlert("Warning", "Please enter your descripcion", "ok");
                }

            Trabajador trabajador = new Trabajador();
                trabajador.Id = TxtId.Text;
                trabajador.Nombre = nombres;
                trabajador.Description = descripciones;
                trabajador.DNI = DNIS;
                trabajador.Celular = Celulares;
                trabajador.Direccion = Direcciones;
                trabajador.Correo = Correos;
            bool isUpdated = await trabajadoresRepositorio.Update(trabajador);
                if (isUpdated) 
                {
                await Navigation.PopModalAsync();
                }
                else 
                {
                await DisplayAlert("Error", "Error al actualizar", "ok");
            }
        }
}
}
