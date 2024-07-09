namespace VVCBotPessoal
{
    public class AcaoModel
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
        public string XPath { get; set; }
        public AcaoModel(string sigla, string nome, string url, string xPath)
        {
            Sigla = sigla;
            Nome = nome;
            Url = url;
            XPath = xPath;
        }
    }
}