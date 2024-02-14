/*
    Esta é a entidade Todo.cs. 
    Representação do modelo de dados.
    Esta é uma Classe de Contesto.
*/

using Microsoft.EntityFrameworkCore;

/*
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/

/*
    // Ignorar bibliotecas criadas por padrão
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
*/

namespace TodoApi
{
    public class TodoDb: DbContext
    {
        public TodoDb(DbContextOptions options) : base(options) { }

        public DbSet<Todo> Todos {get; set;}

    }

}