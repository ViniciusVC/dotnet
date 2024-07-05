//using VVCAPICalculadoraXUnit.Models;
using Xunit; // Usar Biblioteca Xunit.

namespace VVC.APICalculadoraXUnit.Tests
{
  public class UnitTest1
  {
    // A tag Fact indica que este é um método de teste.
    [Fact]
    public void Soma_DeveRetornarOValorCorreto()
    {
        Calculadora calc = new Calculadora(10, 20); // O construtor recebe 2 parametros.
        calc.somar(); // Metodo somar da entidade calculadora.

        //Verifica se o resultado é igual a 30        
        
        //Assert.AreEqual(30, resultado); // Erro - 'Assert' does not contain a definition for 'AreEqual'
        //Assert.That(30, Is.EqualTo(resultado)); // Erro - 'Assert' does not contain a definition for 'That' 
        //ClassicAssert.AreEqual(30, resultado); // Erro - The name 'ClassicAssert' does not exist in the current context 
        Assert.Equal(30, calc);
    }

    // A tag Theory executa o mesmo teste com uma série de parâmetros. 
    // Caso algum dos parâmetros gere um resultado inesperado, ela é considerada falha.
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void RestoDivisao_DeveRetornarZero(int value)
    {
        var calc = new Calculadora();
        var resultado = calc.RestoDivisao(10, value);
        //var resultado = c.RestoDivisao(12, value);
        //Verifica se o resto da divisão é 0
        Assert.Equal(0, resultado.resto);
    }

    [Fact]
    public void RestoDivisao_DeveRetornarOValorCorreto()
    {
        var calc = new Calculadora();
        var resultado = calc.RestoDivisao(10, 3);
        //Verifica se o quociente da divisão é 3 e o resto 1
        Assert.Equal(3, resultado.quociente);
        Assert.Equal(1, resultado.resto);
    }

    [Fact]
    public void Subtracao_DeveRetornarOValorCorreto()
    {
        var calc = new Calculadora(20,10); // O construtor recebe 2 parametros.
        calc.Subtrair();
        //Verifica se o resultado é igual a 10
        Assert.Equal(10, calc);
    }

    [Fact]
    public void Divisao_DeveRetornarOValorCorreto()
    {
        var calc = new Calculadora(100,10); // O construtor recebe 2 parametros.
        calc.Dividir(); // Metodo dividir da entidade calculadora.
        //Verifica se o resultado é igual a 10
        Assert.Equal(10, calc);
    }

    [Fact]
    public void Multiplicao_DeveRetornarOValorCorreto()
    {
        var calc = new Calculadora(5,2); // O construtor recebe 2 parametros.
        calc.Multiplicar(); 
        //Verifica se o resultado é igual a 10
        Assert.Equal(10, calc);
    }
  }
}