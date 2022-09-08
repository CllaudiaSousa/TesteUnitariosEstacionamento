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

        //setup prepara um cenário onde se instância uma variavel ou objeto para ser utilizado em vários métodos do sistema 
            public VeiculoTeste(ITestOutputHelper _saidaConsoleTeste)
            {

            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor Invocado.");
           veiculo = new Veiculo();
               
            }

        //A notação DisplayName permite nomear o teste  (DisplayName = "Teste nº1")
        //A notação Trait permite eclarecer o que é aquele teste, a ação que ele executa ou pra resumir as características (chave/valor)    [Trait("Funcionalidade", "Acelerar")]
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

        // A notação Skip é usado, na hora da execução, que o teste seja pulado
        [Fact (Skip = "Teste ainda não implmentada. Ignorar")]
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
            //A notação Contais permite verificar e contém um determinado valor dentro da string
            Assert.Contains("Ficha do Veiculo:", dados);
        }

        [Fact]
        public void TestaNomePropietarioVeiculoComMenosDeTresCaracteres()
        {
            //Arrange
            string nomepropietario = "Ab";

            //Assert
            //Anotação Thorows para testar exeções e se passa um parâmetro pra ele qual tipo de exeção esperada
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
            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);

        }


        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose  gt bhh Invocado.");
        }
    }
 
}
