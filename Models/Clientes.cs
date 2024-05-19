﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DaVinci.Models;

namespace DaVinci.Models
{
    public class Clientes
    {
        public int IdCliente { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Sexo { get; set; }

        public string Cidade { get; set; }

        public string Cpf { get; set; }

        //1..N
        public ICollection<Produtos>? Produtos { get; set; }

        public ICollection<Feedbacks>? Feedbacks { get; set; }
    }
}