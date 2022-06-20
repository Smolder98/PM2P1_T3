using PM2P1_T3.Model;
using PM2P1_T3.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PM2P1_T3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                listaPersonas.ItemsSource = await App.DBase.getListPersona();
            }
            catch (Exception e)
            {

            }
        }

        private async void toolMenu1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecondaryPage());
        }

        private async void listaPersonas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var Per = (Persona)e.Item;

            //await DisplayAlert("","Elemento seleccionado: " + Emple.nombre + " Fecha: "+ Emple.fechaIngreso, "OK");

            SecondaryPage view = new SecondaryPage();
            view.BindingContext = Per;

            await Navigation.PushAsync(view);
        }
    }
}
