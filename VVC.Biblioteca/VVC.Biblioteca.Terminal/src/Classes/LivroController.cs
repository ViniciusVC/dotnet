using System;
using System.Threading.Tasks;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;

using VVC.Biblioteca.Terminal.Model;

// using Microsoft.Extensions.Configuration; // String de conexão.

namespace VVC.Biblioteca.Terminal
{

    class LivroController
    {
        private LivroContexto contexto = new LivroContexto();
        private ConnectMessage connectMessage;

        public LivroController()
        {
            connectMessage = new ConnectMessage();
        }

        public void ListarLivros()
        {   
            Console.WriteLine("Carregando lista de Livros...");
            ExibeLivros();
            Console.ReadKey(true);
        }
       
        public async void ExibeLivros()
        {   
            try
            {
                Task<List<Livro>> task = contexto.ListarLivrosDoBanco();
                List<Livro> livros = await task;
                Console.Clear();
                Console.WriteLine("Lista de Livros:");
                Console.WriteLine("=================================================");
                foreach (var livro in livros)
                {
                    Console.WriteLine($"| Id: {livro.Id}, Nome: {livro.LivroNome}, Autor: {livro.LivroAutor}, Publicado: {livro.LivroAnoPublicacao}"); 
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
        
        
        public void CriarLivro()
        {
            try
            {
                Console.Write("Digite o nome do livro: ");
                string nome = Console.ReadLine();
                Console.Write("Digite o autor do livro: ");
                string autor = Console.ReadLine();
                Console.Write("Digite a editora do livro: ");
                string editora = Console.ReadLine();
                Console.Write("Digite o ano de publicação do livro (9999): ");
                string tempData = Console.ReadLine();
                //DateTime anoPublicacao = DateTime.Parse("1999-01-01 104:00:00");
                //DateTime anoPublicacao = DateTime.Now();
                Console.Write("Digite a edição do livro: ");
                string edicao = Console.ReadLine();

                Livro livro = new Livro
                {
                    LivroNome = nome,
                    LivroAutor = autor,
                    LivroEditora = editora,
                    LivroAnoPublicacao = DateTime.Parse("01-01-"+tempData+" 104:00:00"),
                    LivroEdicao = edicao
                };

                //_livros.Add(livro);

                contexto.CriarLivroNoBanco(livro);

                Console.WriteLine("Livro criado com sucesso!");
                Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                connectMessage.Erro();
            }
        }
        




        public void EditarLivro()
        {
            try
            {
                Console.Write("Digite o id do livro que deseja editar: ");
                int id = int.Parse(Console.ReadLine());

                /*
                Livro livro = _livros.FirstOrDefault(l => l.Id == id);
                if (livro == null)
                {
                    Console.WriteLine("Livro não encontrado.");
                    return;
                }
                */

                Console.Write("Digite o novo nome do livro: ");
                string nome = Console.ReadLine();
                Console.Write("Digite o novo autor do livro: ");
                string autor = Console.ReadLine();
                Console.Write("Digite a nova editora do livro: ");
                string editora = Console.ReadLine();
                Console.Write("Digite o novo ano de publicação do livro: ");
                string tempData = Console.ReadLine();
                Console.Write("Digite a nova edição do livro: ");
                string edicao = Console.ReadLine();

                Livro livro = new Livro
                {
                    LivroNome = nome,
                    LivroAutor = autor,
                    LivroEditora = editora,
                    LivroAnoPublicacao = DateTime.Parse("01-01-"+tempData+" 104:00:00"),
                    LivroEdicao = edicao
                };

                contexto.EditarLivroNoBanco(livro);               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                connectMessage.Erro();
            }
        }
        


        

        public void DeletarLivro()
        {
            try
            {
                Console.Write("Digite o id do livro que deseja deletar: ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Livro id="+id+" deletado.");
                Console.ReadKey(true);

                /*
                Livro livro = _livros.FirstOrDefault(l => l.Id == id);
                if (livro == null)
                {
                    Console.WriteLine("Livro não encontrado.");
                    return;
                }

                _livros.Remove(livro);
                */
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                connectMessage.Erro();
            }
        }
        


        
    }
}