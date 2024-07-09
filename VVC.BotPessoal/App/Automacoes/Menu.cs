using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace VVCBotPessoal
{


    public class Menu
    {


        public void MenuBot()
        {
            var desenhoRobo = new DesenhoRobo();

            // Instanciar UI do menu.
            var menu = new MenuView(); 

            bool sairMenu = false;
            ConsoleKeyInfo cki;
            do
            {
                menu.MostrarMenu();
                cki = Console.ReadKey();
                    if(cki.Key == ConsoleKey.D1) 
                    {
                        // -----Teste-de-Conexão------------------------------------------ 
                        var testConnection = new TestConnection();
                        testConnection.TestStringMySQL();
                    }   
                    else if(cki.Key == ConsoleKey.D2) 
                    {
                        // -----Iniciar-automação------------------------------------------ 
                        iniciarAutomacoes();
                    }
                    else if(cki.Key == ConsoleKey.D6 || cki.Key == ConsoleKey.Escape) 
                    {
                        Console.WriteLine("Saindo...");
                        sairMenu = true;
                    }
                    else 
                    {
                        Console.WriteLine("Botão incorreto.");
                        //erroMenu.Mostrar(cki.Key.ToString());
                    }
            } while (!sairMenu);
            Console.WriteLine("-Até logo.");
        }

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

            // -----Teste-Mocado-----------------------------------------
			//var valorAcoesManipulaBD = new ValorAcoesManipulaBD();
            //valorAcoesManipulaBD.GravarValorAcoesAsync("XOM","112,18","2024-07-09");
        }
    }
}