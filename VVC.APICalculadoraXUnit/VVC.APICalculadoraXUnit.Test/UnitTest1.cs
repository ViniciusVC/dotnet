using VVCAPICalculadoraXUnit.API.Models;
using VVCAPICalculadoraXUnit.API.Service;
using Xunit; // Usar Biblioteca Xunit.

namespace VVC.APICalculadoraXUnit.Tests
{
  public class UnitTest1
  {
    // A tag Fact indica que este é um método de teste.
    [Fact]
    public void Soma_DeveRetornarOValorCorreto()
    {
        var calc = new CalculadoraService(10, 20); // O construtor recebe 2 parametros.
        CalculadoraModel resultado = calc.Somar(); // Metodo somar da entidade calculadora.

        //int resposta = int.Parse(calc);
        //Verifica se o resultado é igual a 30        
        
        //Assert.AreEqual(30, resultado); // Erro - 'Assert' does not contain a definition for 'AreEqual'
        //Assert.That(30, Is.EqualTo(resultado)); // Erro - 'Assert' does not contain a definition for 'That' 
        //ClassicAssert.AreEqual(30, resultado); // Erro - The name 'ClassicAssert' does not exist in the current context 
        Assert.Equal(30, resultado.resultado);
    }

    // A tag Theory executa o mesmo teste com uma série de parâmetros. 
    // Caso algum dos parâmetros gere um resultado inesperado, ela é considerada falha.
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    public void RestoDivisao_DeveRetornarZero(int value)
    {
        var calc = new CalculadoraService();
        var resultado = calc.RestoDivisao(10, value);
        //Verifica se o resto da divisão é 0
        Assert.Equal(0, resultado.resto);
    }

    [Fact]
    public void RestoDivisao_DeveRetornarOValorCorreto()
    {
        var calc = new CalculadoraService();
        var resultado = calc.RestoDivisao(10, 3);
        //Verifica se o quociente da divisão é 3 e o resto 1
        Assert.Equal(3, resultado.quociente);
        Assert.Equal(1, resultado.resto);
    }

    [Fact]
    public void Subtracao_DeveRetornarOValorCorreto()
    {
        var calc = new CalculadoraService(20,10); // O construtor recebe 2 parametros.
        var resultado = calc.Subtrair();

        //Verifica se o resultado é igual a 10
        Assert.Equal(10, resultado.resultado);
    }

    [Fact]
    public void Divisao_DeveRetornarOValorCorreto()
    {
        var calc = new CalculadoraService(100,10); // O construtor recebe 2 parametros.
        var resultado = calc.Dividir(); // Metodo dividir da entidade calculadora.
        //Verifica se o resultado é igual a 10
        Assert.Equal(10, resultado.resultado);
    }

    [Fact]
    public void Multiplicao_DeveRetornarOValorCorreto()
    {
        var calc = new CalculadoraService(5,2); // O construtor recebe 2 parametros.
        var resultado = calc.Multiplicar(); 
        //Verifica se o resultado é igual a 10
        Assert.Equal(10, resultado.resultado);
    }
  }
}