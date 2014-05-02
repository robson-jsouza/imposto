using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoImposto.CCOs
{
    public class Cco
    {
        public int Id { get; private set; }
        public string Email { get; set; }
        public int CodUsuario { get; set; }

        public Cco() { }
        public Cco(string Email, int CodUsuario)
        {
            this.Email = Email;
            this.CodUsuario = CodUsuario;
        }
    }
}