using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Teste
{
    public class PatioTeste : IDisposable 
    {

        private Veiculo veiculo;
        private Operador operador;
        
        public ITestOutputHelper SaidaConsoleTeste;

        public PatioTeste(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor Invocado.");
            veiculo = new Veiculo();

            operador = new Operador();
            operador.Nome = "Pedro Fagundes";
        }

        [Fact]
        public void ValidaFaturamentoDoEstacinamentoComUmVeiculo()
        {

            //arrange
            var estacionamento = new Patio();

            //Operador operador = new Operador();
            //operador.Nome = "Clau Fagundes";
            estacionamento.OperadorPatio = operador;


            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Clau Siva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Jeep Regn";
            veiculo.Placa = "asw-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);


            //Act
            double faturamento = estacionamento.TotalFaturado();

            //assert
            Assert.Equal(2, faturamento);

        }

        //Teoria permite trabalhar com um conjunto maior de dados com parâmetros
        //InineData
        [Theory]
        [InlineData("Andre Silva", "ASD-1498", "Preto", "Gol")]
        [InlineData("Clau Siva", "ASW-9999", "Preto", "Jeep Regn")]
        [InlineData("Guel Costa", "BWS-9087", "Prata", "Opala")]
        [InlineData("Pedro Silva", "GDR-0101", "Azul", "Corsa")]

        public void ValidaFaturamentoDoEstacioanamentoComVariosVeiculos(string proprietario,
                                                                        string placa, 
                                                                        string cor, 
                                                                        string modelo)

        {
            //arrenge

            Patio estacioanamento = new Patio();
            estacioanamento.OperadorPatio = operador;

            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacioanamento.RegistrarEntradaVeiculo(veiculo);
            estacioanamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //act
            double faturamento = estacioanamento.TotalFaturado();


            //assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Andre Silva", "ASD-1498", "Preto", "Gol")]
        public void LocalizaVeiculoNoPatioComBaseNoIdTicket
        (string proprietario, string placa, string cor, string modelo)

        {
            //arrenge

            Patio estacioanamento = new Patio();
            estacioanamento.OperadorPatio = operador;

            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacioanamento.RegistrarEntradaVeiculo(veiculo);

            //Act 
            var consultado = estacioanamento.PesquisaVeiculo(veiculo.IdTicket);

            //Assert
            Assert.Contains("### Ticket Estacioanemento Alura ###", consultado.Ticket);
        }

        [Fact]
        public void AlterarDadosDoPropioVeiculo()
        {
            //arrange
            var estacionamento = new Patio();
            estacionamento.OperadorPatio = operador;

            // var veiculo = new Veiculo();
            veiculo.Proprietario = "Otavio Siva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Opala";
            veiculo.Placa = "zxc-8524";
            estacionamento.RegistrarEntradaVeiculo(veiculo);


            var veiculoAlterado = new Veiculo();

            veiculoAlterado.Proprietario = "José Silva";
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Cor = "Preto";
            veiculoAlterado.Modelo = "Preto"; //Alterado
            veiculoAlterado.Placa = "zxc-8524";

            //act  
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Dispose Invocado.");
        }
    }
}
