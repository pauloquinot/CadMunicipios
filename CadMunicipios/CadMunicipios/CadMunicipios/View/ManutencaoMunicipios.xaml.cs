using CadMunicipios.Dao;
using CadMunicipios.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CadMunicipios.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ManutencaoMunicipios : ContentPage
	{
		public ManutencaoMunicipios(Municipio municipio)
        {
            Municipio clienteBinding = municipio;

            InitializeComponent();
            edtCodigo.Text = municipio.Codigo.ToString();
            edtNome.Text = municipio.Nome;
           
        }
        public ManutencaoMunicipios()
        {
            InitializeComponent();

        }

        public void IncluirMunicipio(object o, EventArgs e)
        {
            Municipio municipio = new Municipio();
            try
            {
                municipio.Codigo = int.Parse(edtCodigo.Text);
            }
            catch (Exception ex)
            {
                municipio.Codigo = 0;
            }
            municipio.Nome = edtNome.Text;

            MunicipioDao dao = new MunicipioDao();
            dao.InsereAtualiza(municipio);
            Navigation.PushModalAsync(new ListaMunicipios(""));
        }

        public void ExcluirMunicipio(object o, EventArgs e)
        {


            MunicipioDao dao = new MunicipioDao();
            dao.Deleta(int.Parse(edtCodigo.Text));
            Navigation.PushModalAsync(new ListaMunicipios(""));
        }


        public async void ListarMunicipios(object o, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListaMunicipios(""));
        }
    }
}