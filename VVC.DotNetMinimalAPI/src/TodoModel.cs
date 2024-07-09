// ENTIDADE
// Este arquivo (Todo.cs) é a representação do Modelo de Dados.

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
