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
    public partial class TrabajadoresPage1 : ContentPage
    {
        TrabajadoresRepositorio TrabajadoresRepositorio = new TrabajadoresRepositorio();
        public TrabajadoresPage1()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var Trabajadores = await TrabajadoresRepositorio.GetAll();
            TrabajadoresListView.ItemsSource = null;
            TrabajadoresListView.ItemsSource = Trabajadores;
        }

        private void addToolBarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new TrabajadoresEntry1());
        }

        private void TrabajadoresListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return;
             }
            var trabajador = e.Item as Trabajador;
            Navigation.PushModalAsync(new Detalles(trabajador));
            ((ListView)sender).SelectedItem = null;
        }

        private async void editarTapp_Tapped(object sender, EventArgs e)
        {
            //DisplayAlert("Edit", "Desea Editar xd", "Ok");
            string id = ((TappedEventArgs)e).Parameter.ToString();
            var trabajador = await TrabajadoresRepositorio.GetById(id);
            if (trabajador == null)
            {
                await DisplayAlert("Warning", "Data not encontrada ", "ok");
            }
            trabajador.Id = id;
            await Navigation.PushModalAsync(new TrbajadoresEdit(trabajador));
        }

        private async void deleteTapp_Tapped(object sender, EventArgs e)
        {
            var response=await DisplayAlert("Delete", "Desea eliminar xd", "ok","cancel");
            if(response)
            {
                string id = ((TappedEventArgs)e).Parameter.ToString();
                bool isdelete=await TrabajadoresRepositorio.Delete(id);
                if(isdelete)
                {
                    await DisplayAlert("Informacion", "Trabajadores an sido eliminados", "ok");
                    OnAppearing();
                }
                else
                {
                    await DisplayAlert("Error", "Error al momento de  eliminar", "ok");
                }
            }
        }

        private async void TxtSearch_SearchButtonPressed(object sender, EventArgs e)
        {
            string searchValue = TxtSearch.Text;
            if (!String.IsNullOrEmpty(searchValue))
            {
                var trabajadores = await TrabajadoresRepositorio.GetAllByNombre(searchValue);
                TrabajadoresListView.ItemsSource = null;
                TrabajadoresListView.ItemsSource = trabajadores;
                
            }
            else
            {
                OnAppearing();
            }
        }

        private async void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchValue = TxtSearch.Text;
            if (!String.IsNullOrEmpty(searchValue))
            {
                var trabajadores = await TrabajadoresRepositorio.GetAllByNombre(searchValue);
                TrabajadoresListView.ItemsSource = null;
                TrabajadoresListView.ItemsSource = trabajadores;
               
            }
            else
            {
                OnAppearing();
            }
        }
    }
}