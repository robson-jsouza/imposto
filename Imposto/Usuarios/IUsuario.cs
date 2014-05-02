using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoImposto.Usuarios;

namespace AutoImposto.Conexao
{
    interface IUsuario
    {
        void Inserir(Usuario usuario);
        void Deletar(int Id);
        void Atualizar(Usuario usuario);
        void Receber(int Id);

    }
}
