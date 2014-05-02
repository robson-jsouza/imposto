using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoImposto.Usuarios;

namespace AutoImposto.Empresas
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int CodUsuario { get; set; }
        public string Cco { get; set; }

        public Empresa(string nome, string email, int codUsuario)
        {
            this.CodUsuario = codUsuario;
            this.Nome = nome;
            this.Email = email;
        }

        public Empresa(string nome, string email, string cco, int codUsuario)
        {
            this.Nome = nome;
            this.Email = email;
            this.Cco = cco;
            this.CodUsuario = codUsuario;
        }

        public Empresa(string nome, string email, int codUsuario, int idEmpresa){
            this.Id = idEmpresa;
            this.CodUsuario = codUsuario;
            this.Nome = nome;
            this.Email = email;   
        }

        public Empresa(string nome, string email, int codUsuario, string Cco ,int idEmpresa)
        {
            this.Id = idEmpresa;
            this.CodUsuario = codUsuario;
            this.Nome = nome;
            this.Email = email;
            this.Cco = Cco;
        }
    }
}