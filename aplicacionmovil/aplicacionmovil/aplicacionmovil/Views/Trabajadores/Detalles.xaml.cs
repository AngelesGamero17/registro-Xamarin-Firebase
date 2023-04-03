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
    public partial class Detalles : ContentPage
    {
        internal Detalles(Trabajador trabajador)
        {
            InitializeComponent();
            LabelNombre.Text = trabajador.Nombre;
            LabelDescripcion.Text = trabajador.Description;
            LabelDNI.Text = trabajador.DNI;
            LabelCelular.Text = trabajador.Celular;
             LabelDireccion.Text = trabajador.Direccion;
            LabelCorreo.Text = trabajador.Correo;
        }
    }
}