using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoImposto.Impostos
{
    interface IImposto
    {
        bool Inserir(Imposto imposto);
        bool Deletar(Imposto imposto);
        bool Atualizar(Imposto imposto);
        List<Imposto> ListaImpostos(int Id);
    }
}
