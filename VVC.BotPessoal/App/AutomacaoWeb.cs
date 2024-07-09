using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VVCBotPessoal
{

    public class AutomacaoWeb
    {
        /*
        public IWebDriver driver;
        public AutomacaoWebInvest()
        {        
          driver = new ChromeDriver(); // Apenas uma instancia do Navegador será aberto.
        }
        */

        public void iniciarAutomacoes()
        {
            var driver = new ChromeDriver(); // Apenas uma instancia do Navegador será aberto.
           
            
            // -----Gera-Click------------------------------------------------
            // abrir busca e click para o V-Editor.
            GeraClick geraClick = new GeraClick(driver);
            geraClick.Clicar();

            
            // -----Levantamento-Acoes-----------------------------------------
            // Capturar ações.
            LevantamentoAcoes levantamentoAcoes = new LevantamentoAcoes(driver);
            levantamentoAcoes.CarteiraAcoes();
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