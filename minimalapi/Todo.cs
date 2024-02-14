// ENTIDADE
// Este arquivo (Todo.cs) é a ENTIDADE TodoApi 


// using System.EntityFramerkCore;
// using Microsoft.EntityFramerkCore;

/*
    // Ignorar bibliotecas criadas por padrão
    using System; //Manipular sitema operacional.
    using System.Collections.Generic;
    using System.Linq; // ṕara trabalhar com grande Conjunto de dados.
    using System.Text; // Manipular texto.
    using System.Threading.Tasks; // Processos paralelos (usa nucleos separados).
*/

namespace TodoApi
{

    public class Todo
    {
            
        public int Id { get; set; } // Propriedade Id

        public string? Name { get; set; } // Propriedade Name

        public bool IsComplete { get; set; } // Propriedade IsComplete
        

    }
}

/*
    Tabela : Todo
    Campo: Id
    Campo: Name
    Campo: IsComplete
*/
