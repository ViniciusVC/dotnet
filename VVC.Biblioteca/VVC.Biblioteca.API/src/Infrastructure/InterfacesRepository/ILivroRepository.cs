using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using VVC.Biblioteca.API.Models;

namespace VVC.Biblioteca.API.Repositories
{

    // Classe abstrata (Contrado/Interface)

    public interface ILivroRepository
    {
        
        void Incluir(Livro livro);
        void Alterar(Livro livro);
        void Excluir(Livro livro);
        Task<Livro> SelecionarByPk(int id); // Task: Metodo assincrono.
        Task<IEnumerable<Livro>> Selecionartodos(); // Task: Metodo assincrono.
        Task<bool> SaveAllAsync(); // Task: Metodo assincrono.
    }


}