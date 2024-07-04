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
            Console.WriteLine("Abrindo o navegador. Na pagina do google.");
            driver.Navigate().GoToUrl("https://www.google.com.br/?hl=pt-BR");
            
            Console.WriteLine("Texto que será digitado.");
            driver.FindElement(By.Name("q")).SendKeys("V-Editor3D é uma ferramenta WEB de edição de objetos 3D");

            Console.WriteLine("Digitar na Caixa de texto. E Clicar para buscar.");
            driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/textarea")).Submit();

            Console.WriteLine("Clicar no link.");
            driver.FindElement(By.XPath("/html/body/div[4]/div/div[13]/div/div[2]/div[2]/div/div/div[1]/div/block-component/div/div[1]/div/div/div/div/div[1]/div/div/div/div/div[2]/div/div/div[1]/div/span/a/h3")).Click();
            
            Console.WriteLine("No site de apresentação do V-Editor, abra a ferramenta.");
            driver.FindElement(By.XPath("/html/body/main/div/div/div/div[2]/div[2]/div[1]/div/div/p[2]/a[1]/span/strong")).Click();
        }


        public void CarteiraAcoes()
        {
            Console.WriteLine("Abrindo Ações do Google.");
            driver.Navigate().GoToUrl("https://www.google.com/search?q=Alphabet+BDR&sca_esv=ae3bdbd7c3a37541&sca_upv=1&sxsrf=ADLYWILgg5muaVg-nZfcfFDtDaUfK9ODGA%3A1720075642802&ei=ekWGZuPWMIL35OUPxNyEiAI&ved=0ahUKEwjj-7ON5YyHAxWCO7kGHUQuASEQ4dUDCBA&uact=5&oq=Alphabet+BDR&gs_lp=Egxnd3Mtd2l6LXNlcnAiDEFscGhhYmV0IEJEUjIFEAAYgAQyBRAAGIAEMggQABiABBiiBDIIEAAYgAQYogRIpAZQAFgAcAB4AZABAJgBhAGgAYQBqgEDMC4xuAEDyAEA-AEC-AEBmAIBoAKNAZgDAOIDBRIBMSBAkgcDMC4xoAeDAg&sclient=gws-wiz-serp");         

            string valor1 = driver.FindElement(By.XPath("/html/body/div[5]/div/div[13]/div[3]/div[1]/div[2]/div/div/div/div/div/div/div/div/div/div/div[2]/div[2]/div/div/div/div/div/div[3]/g-card-section/div/g-card-section/div[2]/div[1]/span[1]/span/span[1]")).Text;
            Console.WriteLine("---------------"+valor1+"--------------");
        }

    }


}