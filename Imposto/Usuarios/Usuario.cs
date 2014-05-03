using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoImposto.Usuarios
{
    public class Usuario
    { 
        //public int teste
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Usuario(string Nome, string Email, string Senha)
        {
            this.Nome = Nome;
            this.Email = Email;
            this.Senha = Senha;
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            this.Id = usuarioDAO.getId(this);
        }

        public Usuario(int Id, string Nome, string Email, string senha)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Email = Email;
            this.Senha = senha;
             
        }

        public Usuario() { }
    }
}