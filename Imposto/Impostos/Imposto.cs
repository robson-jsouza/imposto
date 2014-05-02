using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoImposto.Impostos
{
    public class Imposto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CodUsuario { get; set; }

        public Imposto(string nome, int codUsuario)
        {
            this.CodUsuario = codUsuario;
            this.Nome = nome;
        }

        public Imposto(string nome, int codUsuario, int idEmpresa)
        {
            this.CodUsuario = codUsuario;
            this.Nome = nome;
            this.Id = idEmpresa;
        }

    }
}