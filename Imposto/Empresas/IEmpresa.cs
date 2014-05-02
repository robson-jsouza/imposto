using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoImposto.Empresas
{
    interface IEmpresa
    {
        bool Inserir(Empresa empresa);
        bool Deletar(Empresa empresa);
        bool Atualizar(Empresa empresa);
        List<Empresa> ListaEmpresas(int Id);
    }
}
