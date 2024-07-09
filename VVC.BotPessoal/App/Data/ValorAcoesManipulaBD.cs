
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore; // Banco de Dados;

namespace VVCBotPessoal
{

    public class ValorAcoesManipulaBD
    {

        public async void GravarValorAcoesAsync(string sigla,string valorStrg, string dataCotacao)
        {
          Console.WriteLine("- GravarValorAcoesAsync("+sigla+","+valorStrg+","+dataCotacao+"){");
          try{
            

            var context = new ValorAcaoContext();
            Console.WriteLine("- Instanciou o context");

            // Instancia um ValorAcao com as informação .
            var novoValorAcao = new ValorAcao();
            Console.WriteLine("- Instanciou o ValorAcao MODEL");

            // --------------------------------------------------

            // Carregar informação na instancia de ValorAcao.
            novoValorAcao.Sigla = sigla;
            Console.WriteLine("- Aplicando sigla : " + novoValorAcao.Sigla);

            novoValorAcao.Valor = Convert.ToInt16(valorStrg.Replace(",", ""));
            Console.WriteLine("- Aplicando Valor : "+ novoValorAcao.Valor);
            //novoValorAcao.Valor = Convert.ToInt16(Convert.ToDecimal(valorStrg)*100); //valorAcao.Valor = Convert.ToDecimal(valorStrg); //valorStrg.Replace(",", ".")

            novoValorAcao.DataCotacao = Convert.ToDateTime(dataCotacao); //string formattedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Console.WriteLine("- Aplicando Data : "+ novoValorAcao.DataCotacao);

            // --------------------------------------------------


            bool jaExiste;

            // Validar se existe um estudante de mesmo nome já cadastrado.
            // jaExiste = await context.ValorAcao.AnyAsync(valorAcao => valorAcao.DataCotacao == novoValorAcao.DataCotacao); // Task<bool>
            
            // Buscar ação com mesma data:
            ValorAcao valorAcaoExiste = context.ValorAcao.FirstOrDefault(va => va.DataCotacao == novoValorAcao.DataCotacao && va.Sigla == novoValorAcao.Sigla);


            if(valorAcaoExiste==null)
            {
                
                Console.WriteLine("- Salvando novo registro...");
                // Incluir o ValorAcao no context.
                await context.ValorAcao.AddAsync(novoValorAcao);
                  
                // Aplicar todas as alterações ao banco.                 
                await context.SaveChangesAsync();
                Console.WriteLine("- Salvou no banco.");

            }
            else
            {
                // Se exite, upate registro.
                Console.WriteLine("- Sobrescrevendo registro "+ valorAcaoExiste.id+" ...");
                valorAcaoExiste.Valor = novoValorAcao.Valor;
                valorAcaoExiste.DataCotacao = novoValorAcao.DataCotacao;

                context.ValorAcao.Update(valorAcaoExiste);
                await context.SaveChangesAsync();

                Console.WriteLine("- Salvou no banco.");
            }


          }catch(Exception e){
            Console.WriteLine("- ERRO na gravação.");
            Console.WriteLine(e.Message);
          }
          Console.WriteLine("}");
        }

    }

}

