using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using BuscaCEPMobile.Servico.Modelo; //add esse
using Newtonsoft.Json;// e esse

namespace BuscaCEPMobile.Servico
{
    public class ViaCEPServico
    {
        //Controler do MVC
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";
        public static Endereco BuscarEnderecoViaCEP(string cep) //os métodos státicos há necessidade de ter um retorno
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);
            WebClient wc = new WebClient();//resumidamente abriu o navegador, de forma interna
            string Conteudo = wc.DownloadString(NovoEnderecoURL);// baixou a string
            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);//de forma didática ele dezipa o conteúdo
            if(end.cep==null)return null; 
            return end;
        }
    }
}
