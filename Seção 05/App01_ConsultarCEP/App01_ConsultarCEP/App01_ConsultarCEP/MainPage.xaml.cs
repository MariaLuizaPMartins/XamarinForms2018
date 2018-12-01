using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App01_ConsultarCEP.Servico;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnBuscar_OnClicked(object sender, EventArgs e)
        {
            try
            {
                if (CepValido(TxtCep.Text.Trim()))
                {
                    var endereco = ViaCEPServico.BuscarEnderecoViaCEP(TxtCep.Text.Trim());
                    LblResultado.Text = JsonConvert.SerializeObject(endereco);
                }
            }
            catch (Exception exception)
            {
                DisplayAlert("Erro", exception.Message, "OK");
            }
        }

        private bool CepValido(string cep)
        {
            var retorno = true;
            if (!string.IsNullOrEmpty(cep))
            {
                if (cep.Length != 8)
                {
                    DisplayAlert("Erro de validação", "O cep deve conter 8 caracteres.", "OK");
                    retorno = false;
                }
                
                if (!int.TryParse(cep, out int novoCep))
                {
                    DisplayAlert("Erro de validação", "O cep deve conter somente números.", "OK");
                    retorno = false;
                }
            }
            else
            {
                DisplayAlert("Erro de validação", "O cep não pode ser vazio.", "OK");
            }

            return retorno;
        }
    }
}
