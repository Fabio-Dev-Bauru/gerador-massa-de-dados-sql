﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GeradorCliente
{
    public class Cliente
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
        public int StatusClienteId { get; set; }
    }
}