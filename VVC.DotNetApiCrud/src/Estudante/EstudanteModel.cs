//using System;
//using System.Collections.Generic;
//using System.Linq;

// Class MODEL (Modelo de Dados)

namespace Apicrud.Estudante
{

    public class Estudante
    {
        
        public Guid Id { get; init; } // Gera um ID aleatorio (ex:"a076a1d2-86f1-49f4-bc57-6d1629afccb3")
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }

        // metodo construtor da classe Estudante Model.
        public Estudante(string nome)
        {
            Nome = nome;
            Id = Guid.NewGuid();
            Ativo = true;
        }

        public void AtualizarNome(string nome)
        {
            Nome = nome;
        }

        public void Desativar()
        {
            Ativo = false;
        }

    }


}