using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemClub.Framework
{
    public class Resultado
    {
        public bool Sucesso { get; set; }
        public string MensagemGeral { get; set; }
        public List<ResultadoCampo> Campos { get; set; }

        public Resultado()
        {
            this.Sucesso = true;
            this.MensagemGeral = string.Empty;
            this.Campos = new List<ResultadoCampo>();
        }

        public void AddMensagem(string campo, string mensagem)
        {
            this.Campos.Add(new ResultadoCampo(campo, mensagem));
            this.Sucesso = false;
        }

        public void Erro(string mensagem)
        {
            this.Sucesso = false;
            this.MensagemGeral = mensagem;
        }

        public void Ok(string mensagem)
        {
            this.Sucesso = true;
            this.MensagemGeral = mensagem;
        }
    }

    public class ResultadoCampo
    {
        public string Campo { get; set; }
        public string Mensagem { get; set; }

        public ResultadoCampo(string campo, string mensagem)
        {
            this.Campo = campo;
            this.Mensagem = mensagem;
        }
    }
}