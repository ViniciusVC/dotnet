namespace VVCBotPessoal
{
    public class ValorAcaoModel
    {
        //public int Id {get; set;} // O ID é a chave. 

        public string Sigla { get; set; }
        public string DataCotacao { get; set; }
        public decimal Valor { get; set; }

            /*
            public ValorAcaoModel(string sigla, string dataCotacao, decimal valor)
            {
                Sigla = sigla;
                DataCotacao = dataCotacao;
                Valor = valor;
            }
            */
    }
}