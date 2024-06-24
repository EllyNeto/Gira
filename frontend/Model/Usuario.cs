using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Model
{
    public class Usuario
    {
        public int id { get; set; }

        public string? nome { get; set; }

        public DateOnly data_de_nascimento { get; set; }

        public string? telefone { get; set; }

        public string email { get; set; } = null!;

        public string senha { get; set; } = null!;

        public short nivel_acesso { get; set; }


    }
}
