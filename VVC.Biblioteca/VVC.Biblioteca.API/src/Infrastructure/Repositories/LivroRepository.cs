using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
using VVC.Biblioteca.API.Models;


namespace VVC.Biblioteca.API.Repositories
{

    public class LivroRepository : ILivroRepository
    {
        
        private readonly DbvvcbibliotecaContext bibliotecaContext;

        public LivroRepository(DbvvcbibliotecaContext AtualContex)
        {
            bibliotecaContext = AtualContex; // <- 
        }

        public void Alterar(Livro livro)
        {
            // Alterar um registro na tabela clinte.
            bibliotecaContext.Entry(livro).State = EntityState.Modified;
        }
            
            //public void Excluir(int id)
        public void Excluir(Livro livro)
        {
            // Removendo um Livro.
             bibliotecaContext.Livro.Remove(livro);
        }

        public void Incluir(Livro livro)
        {
            // Incluir novo registro na tabela livro.
            bibliotecaContext.Livro.Add(livro);
        }

        public Task<Livro> SelecionarByPk(int id)
        {
            // Buscando um livro.
            return await bibliotecaContext.Livro.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
            
        public Task<IEnumerable<Livro>> Selecionartodos()
        {
           return await bibliotecaContext.Livro.ToListAsync();
        }
          
        public async Task<bool> SaveAllAsync()
        {
            return await bibliotecaContext.SaveChangesAsync() > 0;
            //return await bibliotecaContext.SaveAllAsync() > 0;
        }
            
    }


}