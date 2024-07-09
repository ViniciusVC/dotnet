using System;
using System.Threading.Tasks;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;
using VVC.Biblioteca.Terminal.Model;

// using Microsoft.Extensions.Configuration; // String de conexão.

namespace VVC.Biblioteca.Terminal
{

    class EmprestimoController
    {

        private EmprestimoContexto contexto = new EmprestimoContexto();
        private ConnectMessage connectMessage;

        public EmprestimoController()
        {
            connectMessage = new ConnectMessage();
        }

        public void ListarEmprestimos()
        {   
            Console.WriteLine("Carregando lista de Emprestimos...");
            ExibeEmprestimos();
            Console.ReadKey(true);
        }
       
        public async void ExibeEmprestimos()
        {   
            try
            {
                Console.WriteLine("ExibeEmprestimos()...");
                Task<List<Emprestimo>> task = contexto.ListarEmprestimosDoBanco();
                List<Emprestimo> emprestimos = await task;
                Console.Clear();
                Console.WriteLine("Lista de Emprestimos:");
                Console.WriteLine("=================================================");
                foreach (var emprestimo in emprestimos)
                {
                    Console.WriteLine($"| Id: {emprestimo.Id}, Id Livro: {emprestimo.LceldLivro }, livro: {emprestimo.livroNome }, Id cliente: {emprestimo.LceldCliente }, CPF : {emprestimo.cliCPF }, cliente : {emprestimo.cliNome  }, pegou em  : {emprestimo.LceldEmprestimo}"); 
                }
                Console.WriteLine("=================================================");
                Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERRO!!!ExibeEmprestimos()!!!");
                Console.WriteLine(ex.Message);
                connectMessage.Erro();
            }
        }
        
        public void BuscarEmprestimos()
        {   
            Console.Write("Digite o id do cliente: ");
            int IdCliente = int.Parse(Console.ReadLine());
            Console.WriteLine($"Carregando Emprestimos de {IdCliente}...");
            ExibeEmprestimos(IdCliente);
            Console.ReadKey(true);
        }
        
        public async void ExibeEmprestimos(int IdCliente)
        {   
            try
            {
                Task<List<Emprestimo>> task = contexto.ListarEmprestimosClienteDoBanco(IdCliente);
                List<Emprestimo> emprestimos = await task;
                Console.Clear();
                Console.WriteLine($"Lista de Emprestimos do cliente {IdCliente}:");
                Console.WriteLine("=================================================");
                foreach (var emprestimo in emprestimos)
                {
                    Console.WriteLine($"| Id: {emprestimo.Id}, Id Livro: {emprestimo.LceldLivro }, livro: {emprestimo.livroNome }, CPF : {emprestimo.cliCPF }, Cliente : {emprestimo.cliNome  }, Pegou em  : {emprestimo.LceldEmprestimo}"); 
                }
                Console.WriteLine("=================================================");
                Console.WriteLine("Pressione qualquer tecla para retornar ao menu.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                connectMessage.Erro();
            }
        }
        
        public void CriarEmprestimo()
        {
            try
            {
                Console.Write("Digite o id do cliente: ");
                int IdCliente = int.Parse(Console.ReadLine());
                Console.Write("Digite o id do livro:");
                int IdLivro = int.Parse(Console.ReadLine());
                contexto.CriarEmprestimoNoBanco(IdCliente, IdLivro);
                Console.WriteLine("salvando dados do Emprestimo.");
                Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                connectMessage.Erro();
            }
        }
        




        public void DevolverLivro()
        {
            try
            {
                Console.Write("Digite o ID do Livro devolvido: ");
                int idLivro = int.Parse(Console.ReadLine());
                Console.Write("Digite o ID do Cliente: ");
                int idCliente = int.Parse(Console.ReadLine());
                contexto.DevolveLivroNoBanco(idCliente, idLivro);
                ExibeEmprestimos(idCliente);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                connectMessage.Erro();
            }
        }
        


          


        
    }
}