using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            var novoEnderecoURL = string.Format(EnderecoURL, cep);

            using (var wc = new WebClient())
            {
                var retorno = wc.DownloadString(novoEnderecoURL);
                return JsonConvert.DeserializeObject<Endereco>(retorno);
            }
        }
    }
}
