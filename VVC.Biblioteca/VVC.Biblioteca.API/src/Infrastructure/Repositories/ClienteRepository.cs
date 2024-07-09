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

    public class ClienteRepository : IClienteRepository
    {

        private readonly DbvvcbibliotecaContext _context;

        public ClienteRepository(DbvvcbibliotecaContext Atualcontex)
        {
           _context = Atualcontex; // <- 
        }

        public void Alterar(Cliente cliente)
        {
            // Alterar um registro na tabela clinte.
           _context.Entry(cliente).State = EntityState.Modified;
        }

        public void Excluir(Cliente cliente)
        {
            // Removendo um cliente.
           _context.Cliente.Remove(cliente);
        }

        public void Incluir(Cliente cliente)
        {
            // Incluir novo registro na tabela clinte.
           _context.Cliente.Add(cliente);
        }
            
        public async Task<Cliente> SelecionarByPk(int id)
        {
            // Buscando um cliente.
            return await_context.Cliente.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cliente>> Selecionartodos()
        {
            return await_context.Cliente.ToListAsync();
        }

        // Implementação do metodo assincrono de salvamento de dados.
        public async Task<bool> SaveAllAsync()
        {
            return await_context.SaveChangesAsync() > 0;
            //return await_context.SaveAllAsync() > 0;
        }
            
    }

}