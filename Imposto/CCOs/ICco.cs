using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoImposto.CCOs
{
    interface ICco
    {
        bool Inserir(Cco cco);
        bool Deletar(Cco cco);
        bool Atualizar(Cco cco);
        string getCco(int CodUsuario);
    }
}
