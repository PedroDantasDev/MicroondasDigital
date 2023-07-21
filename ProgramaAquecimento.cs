using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMicroondasDigital
{
    public class ProgramaAquecimento
    {
        public string Nome { get; set; }
        public string Alimento { get; set; }
        public int Tempo { get; set; }
        public int Potencia { get; set; }
        public string CaractereAquecimento { get; set; }
        public string Instrucoes { get; set; }

        public ProgramaAquecimento(string nome, string alimento, int tempo, int potencia, string caractereAquecimento, string instrucoes)
        {
            Nome = nome;
            Alimento = alimento;
            Tempo = tempo;
            Potencia = potencia;
            CaractereAquecimento = caractereAquecimento;
            Instrucoes = instrucoes;
        }
    }
}
