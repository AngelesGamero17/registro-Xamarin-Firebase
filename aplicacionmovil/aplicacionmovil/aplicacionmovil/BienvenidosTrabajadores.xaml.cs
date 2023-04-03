using aplicacionmovil.Views.Trabajadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aplicacionmovil
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BienvenidosTrabajadores : ContentPage
	{
		public BienvenidosTrabajadores ()
		{
			InitializeComponent ();
		}

        private async void ver_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new TrabajadoresPage1 ());
        }
    }
}