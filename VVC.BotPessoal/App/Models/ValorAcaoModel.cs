namespace VVCBotPessoal
{
    public class ValorAcao
    {
        //public int Id {get; set;} // O ID é a chave. 
        public int id { get; set; }
        public string Sigla { get; set; }
        public DateTime DataCotacao { get; set; }
        public int Valor { get; set; }

            /*
            public ValorAcao(string sigla, string dataCotacao, decimal valor)
            {
                Sigla = sigla;
                DataCotacao = dataCotacao;
                Valor = valor;
            }
            */
    }
}