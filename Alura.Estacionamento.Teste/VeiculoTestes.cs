using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Teste
{
    public class VeiculoTeste :  IDisposable
    {
            private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;

        //setup prepara um cen�rio onde se inst�ncia uma variavel ou objeto para ser utilizado em v�rios m�todos do sistema 
            public VeiculoTeste(ITestOutputHelper _saidaConsoleTeste)
            {

            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor Invocado.");
           veiculo = new Veiculo();
               
            }

        //A nota��o DisplayName permite nomear o teste  (DisplayName = "Teste n�1")
        //A nota��o Trait permite eclarecer o que � aquele teste, a a��o que ele executa ou pra resumir as caracter�sticas (chave/valor)    [Trait("Funcionalidade", "Acelerar")]
        [Fact ]
        

        public void TestaVeiculoAcelerarComParamentro10()
        {
            //Arrange
            //var veiculo = new Veiculo();
            
            //Act
            veiculo.Acelerar(10);

            //Assert 
            Assert.Equal(100, veiculo.VelocidadeAtual);

        }

        [Fact]
      
        public void TestarVeiculoFrearComParametro10()
        { 
            //arenge
            //var veiculo = new Veiculo();

            //act
            veiculo.Frear(10);


            //assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        // A nota��o Skip � usado, na hora da execu��o, que o teste seja pulado
        [Fact (Skip = "Teste ainda n�o implmentada. Ignorar")]
        public void ValidaNomePropietarioDoVeiculo()
        {

        }


        
        [Fact]
        public void FichaDeinformacaoDoVeiculo()
        {
            //Arrange 
           //var veiculo = new Veiculo();
            veiculo.Proprietario = "Carlos Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "ZAP-7419";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Variante";

            //Act 
            string dados = veiculo.ToString();

            //Assert
            //A nota��o Contais permite verificar e cont�m um determinado valor dentro da string
            Assert.Contains("Ficha do Veiculo:", dados);
        }

        [Fact]
        public void TestaNomePropietarioVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string nomepropietario = "Ab";

            //Assert
            //Anota��o Thorows para testar exe��es e se passa um par�metro pra ele qual tipo de exe��o esperada
            Assert.Throws<System.FormatException>(

            //Act
            () => new Veiculo(nomepropietario));
        }

        [Fact]
        public void TestaMensagemDeExececaoDoQuartoCaractereDaPlaca()
        {
            //Arrange 
            string placa = "ASDF8888";

            //Act
            var mensagem = Assert.Throws<System.FormatException>(
                
                () => new Veiculo().Placa = placa 

                );

            //Assert
            Assert.Equal("O 4� caractere deve ser um h�fen", mensagem.Message);

        }


        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose  gt bhh Invocado.");
        }
    }
 
}
