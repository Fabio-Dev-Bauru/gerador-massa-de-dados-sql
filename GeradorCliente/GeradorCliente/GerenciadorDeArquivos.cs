using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GeradorCliente
{
    public class GerenciadorDeArquivos
    {
        private static string caminhoDoRelatorio = @"c:\temp\nomes.csv";

        public static List<string> Nomes = new List<string>();
        public static List<string> SobreNomes = new List<string>();

        public static void LerNomes()
        {
            var arquivo = new StreamReader(caminhoDoRelatorio, Encoding.UTF7);
            var conteudo = arquivo.ReadToEnd();
            arquivo.Close();

            var linhas = conteudo.Split(Char.Parse("\n"));
            foreach (var item in linhas)
            {
                if (!item.Contains("nome"))
                {
                    var linha = item.Replace("\r", "");

                    var colunas = linha.Split(Char.Parse(";"));

                    if (!string.IsNullOrWhiteSpace(colunas[0]))
                    {
                        Nomes.Add(colunas[0].Trim());
                    }

                    if (colunas.Length > 1 && !string.IsNullOrWhiteSpace(colunas[1]))
                    {
                        SobreNomes.Add(colunas[1].Trim());
                    }
                }
                
            }
        }

        public static void GerarArquivoDeConsultas(List<string> consultasSql)
        {
            var nomeArquivo = @"c:\temp\consultasSql.sql";
            var arquivo = new StreamWriter(nomeArquivo, false, Encoding.UTF8);

            foreach (var item in consultasSql)
            {
                arquivo.WriteLine(item);
            }

            arquivo.Close();

        }
    }
}
