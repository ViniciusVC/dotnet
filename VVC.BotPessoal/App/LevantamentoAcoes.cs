using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VVCBotPessoal
{

    public class LevantamentoAcoes
    {

        public IWebDriver driver;

        public LevantamentoAcoes(ChromeDriver drivertemp)
        {
            driver = drivertemp;
        }

        public void CarteiraAcoes()
        {
            

            // criando lista de ações. 
            List<AcaoModel> varAcoes = new List<AcaoModel>
            {
                new AcaoModel("Alphabet BDR", "Google", "https://www.google.com/search?q=Alphabet+BDR&sca_esv=ae3bdbd7c3a37541&sca_upv=1&sxsrf=ADLYWILgg5muaVg-nZfcfFDtDaUfK9ODGA%3A1720075642802&ei=ekWGZuPWMIL35OUPxNyEiAI&ved=0ahUKEwjj-7ON5YyHAxWCO7kGHUQuASEQ4dUDCBA&uact=5&oq=Alphabet+BDR&gs_lp=Egxnd3Mtd2l6LXNlcnAiDEFscGhhYmV0IEJEUjIFEAAYgAQyBRAAGIAEMggQABiABBiiBDIIEAAYgAQYogRIpAZQAFgAcAB4AZABAJgBhAGgAYQBqgEDMC4xuAEDyAEA-AEC-AEBmAIBoAKNAZgDAOIDBRIBMSBAkgcDMC4xoAeDAg&sclient=gws-wiz-serp","/html/body/div[4]/div/div[13]/div[3]/div[1]/div[2]/div/div/div/div/div/div/div/div/div/div/div[2]/div[2]/div/div/div/div/div/div[3]/g-card-section/div/g-card-section/div[2]/div[1]/span[1]/span/span[1]"),
                new AcaoModel("IBM NYSE", "IBM", "https://www.google.com/search?q=IBM+NYSE&sca_esv=3434a8317eb1478a&sca_upv=1&sxsrf=ADLYWILcWMUuMM-Tl3Sf1edNRRPS1Pq-eQ%3A1720160090443&ei=Wo-HZpfhGs7d1sQPkMekcA&ved=0ahUKEwiX9pbZn4-HAxXOrpUCHZAjCQ4Q4dUDCBA&uact=5&oq=IBM+NYSE&gs_lp=Egxnd3Mtd2l6LXNlcnAiCElCTSBOWVNFMgUQABiABDIGEAAYFhgeMgYQABgWGB4yBhAAGBYYHjIGEAAYFhgeMgYQABgWGB4yBhAAGBYYHjIGEAAYFhgeMgYQABgWGB4yBhAAGBYYHkjWBlAAWABwAHgBkAEAmAF8oAF8qgEDMC4xuAEDyAEA-AEC-AEBmAIBoAKKAZgDAJIHAzAuMaAH4gQ&sclient=gws-wiz-serp","/html/body/div[4]/div/div[13]/div[3]/div[1]/div[2]/div/div/div/div/div/div/div/div/div/div/div[2]/div[2]/div/div/div/div/div/div[3]/g-card-section/div/g-card-section/div[2]/div[1]/span[1]/span/span[1]"),
                new AcaoModel("XOM","Exxon Mobil Corp.","https://www.google.com/search?q=a%C3%A7%C3%B5es+xom+exxon+mobil+corporation&sca_esv=3434a8317eb1478a&sca_upv=1&sxsrf=ADLYWILHBSb5yemXFVxt5cSmCwOnqMNf-g%3A1720160234786&ei=6o-HZsvYL_HD5OUP3fKv2Aw&ved=0ahUKEwjL9YCeoI-HAxXxIbkGHV35C8sQ4dUDCBA&uact=5&oq=a%C3%A7%C3%B5es+xom+exxon+mobil+corporation&gs_lp=Egxnd3Mtd2l6LXNlcnAiI2HDp8O1ZXMgeG9tIGV4eG9uIG1vYmlsIGNvcnBvcmF0aW9uMgoQIRigARjDBBgKSIkJUIgHWIgHcAF4AZABAJgBmQGgAZkBqgEDMC4xuAEDyAEA-AEC-AEBmAICoAKpAcICChAAGLADGNYEGEeYAwCIBgGQBgiSBwMxLjGgB7UD&sclient=gws-wiz-serp#ip=1","/html/body/div[4]/div/div[13]/div[3]/div[1]/div[2]/div/div/div/div/div/div/div/div/div/div/div[2]/div[2]/div/div/div/div/div/div[3]/g-card-section/div/g-card-section/div[2]/div[1]/span[1]/span/span[1]")
            };

            foreach (AcaoModel acao in varAcoes)
            {
                CapturarAcao(acao.Sigla, acao.Nome, acao.Url, acao.XPath);
            }
        }

        private void CapturarAcao(string acaoSigla, string acaoNome, string acaoURL, string xPath)
        {
          // Tabela ValorAcaoModel
          ValorAcaoModel valorAcao = new ValorAcaoModel();
          valorAcao.Sigla = acaoSigla;
          try{
            Console.WriteLine("╔═══════════════════════════════");
            Console.WriteLine("║ Abrindo ações do "+acaoNome+".");
            driver.Navigate().GoToUrl(acaoURL);

            Console.WriteLine("║ Capturando valor da ação ("+valorAcao.Sigla+").");
            string valorStrg =  driver.FindElement(By.XPath(xPath)).Text;
            valorAcao.Valor = Convert.ToDecimal(valorStrg); //valorStrg.Replace(",", ".")


            Console.WriteLine("║---------------------------------");
            DateTime currentDate = DateTime.Today;
            //string formattedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            valorAcao.DataCotacao = DateTime.Now.ToString("dd-MM-yyyy");
            Console.WriteLine("║ Valor : "+valorAcao.Valor +" em "+valorAcao.DataCotacao);
            Console.WriteLine("╚═══════════════════════════════");

          }catch(Exception e){
            Console.WriteLine("ERRO com ações do "+acaoNome+".");
            Console.WriteLine(e.Message);
          }
        }

    }

}


/*
╔═══════════════════════════════
║ Abrindo ações do Google.
║ Capturando valor da ação (Alphabet BDR).
║---------------------------------
║ Valor : 86,90 em 08-07-2024
╚═══════════════════════════════
╔═══════════════════════════════
║ Abrindo ações do IBM.
║ Capturando valor da ação (IBM NYSE).
║---------------------------------
║ Valor : 176,02 em 08-07-2024
╚═══════════════════════════════
╔═══════════════════════════════
║ Abrindo ações do Exxon Mobil Corp..
║ Capturando valor da ação (XOM).
║---------------------------------
║ Valor : 113,37 em 08-07-2024
╚═══════════════════════════════
*/