using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMicroondasDigital
{
    public interface IMicroondas
    {
        void Aquecer(int tempo, int potencia);
        void ExibirProgramasPreDefinidos();
        void InicioRapido();
        void PausarCancelar();
        void SelecionarProgramaPreDefinido(int indicePrograma);
    }
}
