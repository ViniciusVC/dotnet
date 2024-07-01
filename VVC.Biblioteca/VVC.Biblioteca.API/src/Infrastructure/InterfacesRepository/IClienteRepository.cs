using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using VVC.Biblioteca.API.Models;

namespace VVC.Biblioteca.API.Repositories
{

    // Classe abstrata (Contrado/Interface)

    public interface IClienteRepository
    {
        
        void Incluir(Cliente cliente);
        void Alterar(Cliente cliente);
        void Excluir(Cliente cliente);
        Task<Cliente> SelecionarByPk(int id); // Task: Metodo assincrono.
        Task<IEnumerable<Cliente>> Selecionartodos(); // Task: Metodo assincrono.
        Task<bool> SaveAllAsync(); // Task: Metodo assincrono.
    }


}