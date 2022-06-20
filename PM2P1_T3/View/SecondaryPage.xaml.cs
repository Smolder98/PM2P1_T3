using PM2P1_T3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2P1_T3.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondaryPage : ContentPage
    {
        public SecondaryPage()
        {
            InitializeComponent();
        }


        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Nombres.Text) ||
               string.IsNullOrEmpty(Apellidos.Text) ||
               string.IsNullOrEmpty(Edad.Text) ||
               string.IsNullOrEmpty(Correo.Text) ||
               string.IsNullOrEmpty(Direccion.Text))
            {
                mensaje("Aviso", "De de llenar todos los campos");
                return;
            }

            if (int.Parse(Edad.Text) < 0)
            {
                mensaje("Aviso", "La edad debe se mayor a cero");
                return;
            }

            if (!ValidateEmail(Correo.Text))
            {
                mensaje("Aviso", "Correo no valido");
                return;
            }



            var _id = (string.IsNullOrEmpty(Id.Text)) ? 0 : int.Parse(Id.Text);

            Persona persona = new Persona()
            {
                id = _id,
                nombres = Nombres.Text,
                apellidos = Apellidos.Text,
                edad = int.Parse(Edad.Text),
                correo = Correo.Text,
                direccion = Direccion.Text
            };

            var result = await App.DBase.insertUpdatePersona(persona);

            if (result > 0)
            {
                mensaje("Aviso", "Trasaccion realizada correctamente");
            }
            else
            {
                mensaje("Aviso", "La trasaccion no se pudo realizar");
            }

            limpiar();

        }

        public bool ValidateEmail(string email)
        {
            Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return EmailRegex.IsMatch(email);
        }


        private void limpiar()
        {
            Id.Text = "";
            Nombres.Text = "";
            Apellidos.Text = "";
            Edad.Text = "";
            Correo.Text = "";
            Direccion.Text = "";
        }

        public async void mensaje(string titulo, string cuerpo)
        {
            await DisplayAlert(titulo, cuerpo, "OK");
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(Id.Text))
            {
                mensaje("Aviso", "Seleccione una persona");
                return;
            }

            var _id = (string.IsNullOrEmpty(Id.Text)) ? 0 : int.Parse(Id.Text);
            Persona persona = new Persona()
            {
                id = _id
            };

            var result = await App.DBase.deletePersona(persona);

            if (result > 0)
            {
                mensaje("Aviso", "Trasaccion realizada correctamente");
            }
            else
            {
                mensaje("Aviso", "La trasaccion no se pudo realizar");
            }

            limpiar();
        }

        private void btnLimpiar_Clicked(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}