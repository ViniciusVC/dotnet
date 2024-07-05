using System;
using System.Collections.Generic;
using System.Linq;

namespace VVCBotPessoal
{
    public class AcaoModel
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }

        public AcaoModel(string sigla, string nome, string url)
        {
            Sigla = sigla;
            Nome = nome;
            Url = url;
        }
    }
}