namespace calculos.tests;

public class CalculadoraTest
{
    // A tag Fact indica que este é um método de teste.
    [Fact]
    public void Soma_DeveRetornarOValorCorreto()
    {
        Calculadora c = new Calculadora();
        var resultado = c.Soma(10, 20);

        //Verifica se o resultado é igual a 30        
        
        //Assert.AreEqual(30, resultado); // Erro - 'Assert' does not contain a definition for 'AreEqual'
        //Assert.That(30, Is.EqualTo(resultado)); // Erro - 'Assert' does not contain a definition for 'That' 
        //ClassicAssert.AreEqual(30, resultado); // Erro - The name 'ClassicAssert' does not exist in the current context 
        Assert.Equal(30, resultado);
    }

    // A tag Theory executa o mesmo teste com uma série de parâmetros. 
    // Caso algum dos parâmetros gere um resultado inesperado, ela é considerada falha.
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void RestoDivisao_DeveRetornarZero(int value)
    {
        Calculadora c = new Calculadora();
        var resultado = c.RestoDivisao(12, value);
        //Verifica se o resto da divisão é 0
        Assert.Equal(0, resultado.resto);
    }

    [Fact]
    public void RestoDivisao_DeveRetornarOValorCorreto()
    {
        Calculadora c = new Calculadora();
        var resultado = c.RestoDivisao(10, 3);
        //Verifica se o quociente da divisão é 3 e o resto 1
        Assert.Equal(3, resultado.quociente);
        Assert.Equal(1, resultado.resto);
    }

    [Fact]
    public void Subtracao_DeveRetornarOValorCorreto()
    {
        Calculadora c = new Calculadora();
        var resultado = c.Subtracao(20, 10);
        //Verifica se o resultado é igual a 10
        Assert.Equal(10, resultado);
    }

    [Fact]
    public void Divisao_DeveRetornarOValorCorreto()
    {
        Calculadora c = new Calculadora();
        var resultado = c.Divisao(100, 10);
        //Verifica se o resultado é igual a 10
        Assert.Equal(10, resultado);
    }

    [Fact]
    public void Multiplicao_DeveRetornarOValorCorreto()
    {
        Calculadora c = new Calculadora();
        var resultado = c.Multiplicao(5, 2);
        //Verifica se o resultado é igual a 10
        Assert.Equal(10, resultado);
    }
}
