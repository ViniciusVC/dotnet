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
        
        private readonly DbvvcbibliotecaContext _context;

        public LivroRepository(DbvvcbibliotecaContext AtualContex)
        {
            _context = AtualContex; // <- 
        }

        public void Alterar(Livro livro)
        {
            // Alterar um registro na tabela clinte.
            _context.Entry(livro).State = EntityState.Modified;
        }
            
            //public void Excluir(int id)
        public void Excluir(Livro livro)
        {
            // Removendo um Livro.
             _context.Livro.Remove(livro);
        }

        public void Incluir(Livro livro)
        {
            // Incluir novo registro na tabela livro.
            _context.Livro.Add(livro);
        }

        public Task<Livro> SelecionarByPk(int id)
        {
            // Buscando um livro.
            return await _context.Livro.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
            
        public Task<IEnumerable<Livro>> Selecionartodos()
        {
           return await _context.Livro.ToListAsync();
        }
          
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
            //return await _context.SaveAllAsync() > 0;
        }
            
    }


}