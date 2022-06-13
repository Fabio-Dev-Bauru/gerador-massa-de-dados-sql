using System;

namespace GeradorCliente
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            GerenciadorDeArquivos.LerNomes();

            var nomes = GerenciadorDeArquivos.Nomes;
            var sobrenomes = GerenciadorDeArquivos.SobreNomes;

            var gerador = new GeradorDeDados(nomes, sobrenomes);

            var numClientes = 10;
            var clientes = gerador.GerarListaDeClientes(numClientes);
            var consultas = gerador.GerarConsultaSql(clientes);

            GerenciadorDeArquivos.GerarArquivoDeConsultas(consultas);
        }
    }
}
