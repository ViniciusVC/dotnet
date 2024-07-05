using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVCBotPessoal
{

    public class AutomacaoWeb
    {

        public IWebDriver driver;

        public AutomacaoWeb()
        {
            driver = new ChromeDriver(); // Apenas de instancias o Navegador já será aberto.
        }

        public void ClickVEditor()
        {
          try{
            Console.WriteLine("╔═════════════════════════════════════════════════");
            Console.WriteLine("║ Abrindo o navegador. Na pagina do google.");
            driver.Navigate().GoToUrl("https://www.google.com.br/?hl=pt-BR");
            
            Console.WriteLine("║ Texto que será digitado.");
            driver.FindElement(By.Name("q")).SendKeys("V-Editor3D é uma ferramenta WEB de edição de objetos 3D");

            Console.WriteLine("║ Digitar na Caixa de texto. E Clicar para buscar.");
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/textarea")).Submit();

            Console.WriteLine("║ Clicar no link.");
            driver.FindElement(By.XPath("/html/body/div[4]/div/div[13]/div/div[2]/div[2]/div/div/div[1]/div/block-component/div/div[1]/div/div/div/div/div[1]/div/div/div/div/div[2]/div/div/div[1]/div/span/a/h3")).Click();
            
            Console.WriteLine("║ No site de apresentação do V-Editor, abra a ferramenta.");
            driver.FindElement(By.XPath("/html/body/main/div/div/div/div[2]/div[2]/div[1]/div/div/p[2]/a[1]/span/strong")).Click();
            Console.WriteLine("╚═════════════════════════════════════════════════");
          }catch(Exception e){
            Console.WriteLine("ERRO com V-Editor.");
            Console.WriteLine(e.Message);
          }
        }


        public void CarteiraAcoes()
        {
            /*
            Console.WriteLine("Abrindo Ações do Google.");
            driver.Navigate().GoToUrl("https://www.google.com/search?q=Alphabet+BDR&sca_esv=ae3bdbd7c3a37541&sca_upv=1&sxsrf=ADLYWILgg5muaVg-nZfcfFDtDaUfK9ODGA%3A1720075642802&ei=ekWGZuPWMIL35OUPxNyEiAI&ved=0ahUKEwjj-7ON5YyHAxWCO7kGHUQuASEQ4dUDCBA&uact=5&oq=Alphabet+BDR&gs_lp=Egxnd3Mtd2l6LXNlcnAiDEFscGhhYmV0IEJEUjIFEAAYgAQyBRAAGIAEMggQABiABBiiBDIIEAAYgAQYogRIpAZQAFgAcAB4AZABAJgBhAGgAYQBqgEDMC4xuAEDyAEA-AEC-AEBmAIBoAKNAZgDAOIDBRIBMSBAkgcDMC4xoAeDAg&sclient=gws-wiz-serp");         

            string valor1 = driver.FindElement(By.XPath("/html/body/div[5]/div/div[13]/div[3]/div[1]/div[2]/div/div/div/div/div/div/div/div/div/div/div[2]/div[2]/div/div/div/div/div/div[3]/g-card-section/div/g-card-section/div[2]/div[1]/span[1]/span/span[1]")).Text;
            Console.WriteLine("---------------"+valor1+"--------------");
            */

            // criando lista de ações. 
            List<AcaoModel> varAcoes = new List<AcaoModel>
            {
                new AcaoModel("Alphabet BDR", "Google", "https://www.google.com/search?q=Alphabet+BDR&sca_esv=ae3bdbd7c3a37541&sca_upv=1&sxsrf=ADLYWILgg5muaVg-nZfcfFDtDaUfK9ODGA%3A1720075642802&ei=ekWGZuPWMIL35OUPxNyEiAI&ved=0ahUKEwjj-7ON5YyHAxWCO7kGHUQuASEQ4dUDCBA&uact=5&oq=Alphabet+BDR&gs_lp=Egxnd3Mtd2l6LXNlcnAiDEFscGhhYmV0IEJEUjIFEAAYgAQyBRAAGIAEMggQABiABBiiBDIIEAAYgAQYogRIpAZQAFgAcAB4AZABAJgBhAGgAYQBqgEDMC4xuAEDyAEA-AEC-AEBmAIBoAKNAZgDAOIDBRIBMSBAkgcDMC4xoAeDAg&sclient=gws-wiz-serp"),
                new AcaoModel("IBM NYSE", "IBM", "https://www.google.com/search?q=IBM+NYSE&sca_esv=3434a8317eb1478a&sca_upv=1&sxsrf=ADLYWILcWMUuMM-Tl3Sf1edNRRPS1Pq-eQ%3A1720160090443&ei=Wo-HZpfhGs7d1sQPkMekcA&ved=0ahUKEwiX9pbZn4-HAxXOrpUCHZAjCQ4Q4dUDCBA&uact=5&oq=IBM+NYSE&gs_lp=Egxnd3Mtd2l6LXNlcnAiCElCTSBOWVNFMgUQABiABDIGEAAYFhgeMgYQABgWGB4yBhAAGBYYHjIGEAAYFhgeMgYQABgWGB4yBhAAGBYYHjIGEAAYFhgeMgYQABgWGB4yBhAAGBYYHkjWBlAAWABwAHgBkAEAmAF8oAF8qgEDMC4xuAEDyAEA-AEC-AEBmAIBoAKKAZgDAJIHAzAuMaAH4gQ&sclient=gws-wiz-serp"),
                new AcaoModel("XOM","Exxon Mobil Corp.","https://www.google.com/search?q=a%C3%A7%C3%B5es+xom+exxon+mobil+corporation&sca_esv=3434a8317eb1478a&sca_upv=1&sxsrf=ADLYWILHBSb5yemXFVxt5cSmCwOnqMNf-g%3A1720160234786&ei=6o-HZsvYL_HD5OUP3fKv2Aw&ved=0ahUKEwjL9YCeoI-HAxXxIbkGHV35C8sQ4dUDCBA&uact=5&oq=a%C3%A7%C3%B5es+xom+exxon+mobil+corporation&gs_lp=Egxnd3Mtd2l6LXNlcnAiI2HDp8O1ZXMgeG9tIGV4eG9uIG1vYmlsIGNvcnBvcmF0aW9uMgoQIRigARjDBBgKSIkJUIgHWIgHcAF4AZABAJgBmQGgAZkBqgEDMC4xuAEDyAEA-AEC-AEBmAICoAKpAcICChAAGLADGNYEGEeYAwCIBgGQBgiSBwMxLjGgB7UD&sclient=gws-wiz-serp#ip=1")
            };

            foreach (AcaoModel acao in varAcoes)
            {
                Mostrar(acao.Sigla, acao.Nome, acao.Url);
            }
        }

        private void Mostrar(string acaoSigla, string acaoNome, string acaoURL)
        {
          try{
            Console.WriteLine("╔═══════════════════════════════");
            Console.WriteLine("║ Abrindo ações do "+acaoNome+".");
            driver.Navigate().GoToUrl(acaoURL);             
            Console.WriteLine("║ Capturando valor da ação ("+acaoSigla+").");
            string valorAtual = driver.FindElement(By.XPath("/html/body/div[4]/div/div[13]/div[3]/div[1]/div[2]/div/div/div/div/div/div/div/div/div/div/div[2]/div[2]/div/div/div/div/div/div[3]/g-card-section/div/g-card-section/div[2]/div[1]/span[1]/span/span[1]")).Text;
            Console.WriteLine("║---------------------------------");
            DateTime currentDate = DateTime.Today;
            //string formattedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string formattedDate = DateTime.Now.ToString("dd-MM-yyyy");
            Console.WriteLine("║ Valor : "+valorAtual +" em "+formattedDate);
            Console.WriteLine("╚═══════════════════════════════");
          }catch(Exception e){
            Console.WriteLine("ERRO com ações do "+acaoNome+".");
            Console.WriteLine(e.Message);
          }
        }

    }


}