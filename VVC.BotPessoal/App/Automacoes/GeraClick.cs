using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VVCBotPessoal
{

    public class GeraClick
    {

        public IWebDriver driver;

        public GeraClick(ChromeDriver drivertemp)
        {
            driver = drivertemp;
        }

        public void Clicar()
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
    }

}

/*
╔═════════════════════════════════════════════════
║ Abrindo o navegador. Na pagina do google.
║ Texto que será digitado.
║ Digitar na Caixa de texto. E Clicar para buscar.
║ Clicar no link.
║ No site de apresentação do V-Editor, abra a ferramenta.
╚═════════════════════════════════════════════════
*/