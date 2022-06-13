using System;
using System.Collections.Generic;
using System.Text;

namespace GeradorCliente
{
    public class GeradorDeDados
    {
        private List<string> nomes;
        private List<string> sobrenomes;

        private List<string> NomeCompleto = new List<string>();
        private List<string> CPFs = new List<string>();
        

        public GeradorDeDados(List<string> nomes, List<string> sobrenomes)
        {
            this.nomes = nomes;
            this.sobrenomes = sobrenomes;
        }

        public List<Cliente> GerarListaDeClientes(int numeroClientes)
        {
            var clientes = new List<Cliente>();

            while (clientes.Count < numeroClientes)
            {
                var id = GerarId();
                var nome = GerarNomeCompleto();
                var email = GerarEmail(nome);
                var cpf = GerarCPF();
                var fone = GerarTelefone();
                var statusCliente = 1;

                var cliente = new Cliente { Id = id, Nome = nome, Email = email, CPF = cpf, Fone = fone, StatusClienteId = statusCliente };
                clientes.Add(cliente);
            }

            return clientes;
        }

        public List<string> GerarConsultaSql(List<Cliente> clientes)
        {
            var modeloConsulta = "insert into cliente (id, nome, cpf, email, fone, statusClienteId) " +
                "values (convert(binary(36), '@id'), '@nome', '@cpf', '@email', '@fone', @statusClienteId);";

            var consultasSql = new List<string>();

            foreach (var item in clientes)
            {
                var consulta = modeloConsulta;
                consulta = consulta.Replace("@id", item.Id);
                consulta = consulta.Replace("@nome", item.Nome);
                consulta = consulta.Replace("@cpf", item.CPF);
                consulta = consulta.Replace("@email", item.Email);
                consulta = consulta.Replace("@fone", item.Fone);
                consulta = consulta.Replace("@statusClienteId", item.StatusClienteId.ToString());

                consultasSql.Add(consulta);
            }

            return consultasSql;
        }

        private string GerarTelefone()
        {
            var r = new Random();
            var telefone = string.Empty;

            for (var i = 1; i <= 2; i++)
            {
                telefone = $"{r.Next(1, 9)}";
            }

            telefone += " ";

            for (var i = 1; i <= 8; i++)
            {
                telefone += $"{r.Next(0, 9)}";
            }

            return telefone;

        }

        private string GerarCPF()
        {
            var cpfValido = false;

            var r = new Random();
            var cpf = string.Empty;

            while (!cpfValido)
            {
                cpf = string.Empty;

                for (var i = 1; i <= 11; i++)
                {
                    cpf += $"{r.Next(0, 9)}";
                }

                if (!string.IsNullOrEmpty(cpf) && !CPFs.Contains(cpf) && cpf != "00000000000" && cpf.Length == 11)
                    cpfValido = true;
            }

            return cpf;
        }

        private string GerarId()
        {
            var id = Guid.NewGuid().ToString();
            return id;
        }

        private string GerarEmail(string nome)
        {
            var setTeype = new List<string> { ".", "_" };
            var r = new Random();
            var c = setTeype[r.Next(0, 1)];

            var email = nome.ToLower().Replace(" ", c);
            email = RemoverCaracteresEspeciais(email);

            email = $"{email}@gmail.com";
            return email;
        }

        private string RemoverCaracteresEspeciais(string nome)
        {
            return nome
                .Replace("á", "a")
                .Replace("à", "a")
                .Replace("ã", "a")
                .Replace("é", "e")
                .Replace("ê", "e")
                .Replace("ë", "e")
                .Replace("ì", "i")
                .Replace("ó", "o")
                .Replace("ô", "o")
                .Replace("ö", "o")
                .Replace("õ", "o")
                .Replace("ú", "u")
                .Replace("ù", "u")
                .Replace("ü", "u");
        }

        private string GerarNomeCompleto()
        {
            var nomeValido = false;

            var r = new Random();
            var nomeCompleto = string.Empty;

            while (!nomeValido)
            {
                var nome = nomes[r.Next(0, nomes.Count - 1)];
                var nome2 = nomes[r.Next(0, nomes.Count - 1)];
                var sobrenome = sobrenomes[r.Next(0, sobrenomes.Count - 1)];
                var sobrenome2 = sobrenomes[r.Next(0, sobrenomes.Count - 1)];

                var contaNome = r.Next(1, 2);
                var contaSobreNome = r.Next(1, 2);

                if (contaNome > 1)
                    nome = $"{nome} {nome2} ";

                if (contaSobreNome > 1)
                    sobrenome = $"{sobrenome} {sobrenome2}";

                nomeCompleto = $"{nome} {sobrenome}";

                if (!NomeCompleto.Contains(nomeCompleto))
                    nomeValido = true;

            }

            return nomeCompleto;
        }

    }
}
