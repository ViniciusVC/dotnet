using System;
using System.Threading.Tasks;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;
using VVC.Biblioteca.Terminal.Model;

// using Microsoft.Extensions.Configuration; // String de conexão.

namespace VVC.Biblioteca.Terminal
{

    class ClienteController
    {

        private ClienteContexto contexto = new ClienteContexto();
        private ConnectMessage connectMessage;

        public ClienteController()
        {
            connectMessage = new ConnectMessage();
        }

        public void ListarClientes()
        {   
            Console.WriteLine("Carregando lista de Clientes...");
            ExibeClientes();
            Console.ReadKey(true);
        }
       
        public async void ExibeClientes()
        {   
            try
            {
                Task<List<Cliente>> task = contexto.ListarClientesDoBanco();
                List<Cliente> clientes = await task;
                Console.Clear();
                Console.WriteLine("Lista de Clientes:");
                Console.WriteLine("=================================================");
                foreach (var cliente in clientes)
                {
                    Console.WriteLine($"| Id: {cliente.Id}, , CPF: {cliente.CliCPF}, Nome: {cliente.CliNome}, Cidade: {cliente.CliCidade}, Email: {cliente.CliEmail}"); 
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
        
        
        public void CriarCliente()
        {
            try
            {
                Console.Write("Digite o cpf do cliente: ");
                string cpf = Console.ReadLine();
                Console.Write("Digite o nome do cliente: ");
                string nome = Console.ReadLine();
                Console.Write("Digite a endereco do cliente: ");
                string endereco = Console.ReadLine();
                Console.Write("Digite a cidade do cliente: ");
                string cidade = Console.ReadLine();
                Console.Write("Digite o bairro do cliente: ");
                string bairro = Console.ReadLine();
                Console.Write("Digite o numero do cliente: ");
                string numero = Console.ReadLine();
                Console.Write("Digite o celular do cliente: ");
                string telefoneCelular = Console.ReadLine();
                Console.Write("Digite o telefone fixo do cliente: ");
                string telefoneFixo = Console.ReadLine();
                Console.Write("Digite o e-mail do cliente: ");
                string email = Console.ReadLine();
                
                Cliente cliente = new Cliente
                {
                    CliCPF = cpf,
                    CliNome = nome,
                    CliEndereco = endereco,
                    CliCidade = cidade,
                    CliBairro = bairro,
                    CliNumero = numero,
                    CliTelefoneCelular = telefoneCelular,
                    CliTelefoneFixo = telefoneFixo,
                    CliEmail = email
                };

                //_clientes.Add(cliente);

                contexto.CriarClienteNoBanco(cliente);

                Console.WriteLine("salvando dados do Cliente.");
                Console.ReadKey(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                connectMessage.Erro();
            }
        }
        




        public void EditarCliente()
        {
            try
            {
                Console.Write("Digite o id do cliente que deseja editar: ");
                int id = int.Parse(Console.ReadLine());

                /*
                Cliente cliente = _clientes.FirstOrDefault(l => l.Id == id);
                if (cliente == null)
                {
                    Console.WriteLine("Cliente não encontrado.");
                    return;
                }
                */

                Console.Write("Digite o cpf do cliente: ");
                string cpf = Console.ReadLine();
                Console.Write("Digite o nome do cliente: ");
                string nome = Console.ReadLine();
                Console.Write("Digite a endereco do cliente: ");
                string endereco = Console.ReadLine();
                Console.Write("Digite a cidade do cliente: ");
                string cidade = Console.ReadLine();
                Console.Write("Digite o bairro do cliente: ");
                string bairro = Console.ReadLine();
                Console.Write("Digite o numero do cliente: ");
                string numero = Console.ReadLine();
                Console.Write("Digite o celular do cliente: ");
                string telefoneCelular = Console.ReadLine();
                Console.Write("Digite o telefone fixo do cliente: ");
                string telefoneFixo = Console.ReadLine();
                Console.Write("Digite o e-mail do cliente: ");
                string email = Console.ReadLine();

                Cliente cliente = new Cliente
                {
                    CliCPF = cpf,
                    CliNome = nome,
                    CliEndereco = endereco,
                    CliCidade = cidade,
                    CliBairro = bairro,
                    CliNumero = numero,
                    CliTelefoneCelular = telefoneCelular,
                    CliTelefoneFixo = telefoneFixo,
                    CliEmail = email
                };

                contexto.EditarClienteNoBanco(cliente);               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                connectMessage.Erro();
            }
        }
        


        

        public void DeletarCliente()
        {
            try
            {
                Console.Write("Digite o id do cliente que deseja deletar: ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Cliente id="+id+" deletado.");
                Console.ReadKey(true);

                /*
                Cliente cliente = _clientes.FirstOrDefault(l => l.Id == id);
                if (cliente == null)
                {
                    Console.WriteLine("Cliente não encontrado.");
                    return;
                }

                _clientes.Remove(cliente);
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