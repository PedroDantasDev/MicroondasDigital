using System.Text;

namespace ProjetoMicroondasDigital
{
    public class Microondas : IMicroondas
    {
        private readonly int _tempoMinimo;
        private readonly int _tempoMaximo;
        private readonly int _potenciaPadrao;
        private int _tempo;
        private int _potencia;
        private bool _aquecendo;

        private List<ProgramaAquecimentoCustomizado> _programasCustomizados;
        private IEnumerable<object> programasPreDefinidos;
        private int tempo;
        private int v;
        private object twm;

        public Microondas(int tempoMinimo, int tempoMaximo, int potenciaPadrao)
        {
            _tempoMinimo = tempoMinimo;
            _tempoMaximo = tempoMaximo;
            _potenciaPadrao = potenciaPadrao;
            _tempo = 0;
            _potencia = potenciaPadrao;
            _aquecendo = false;
            _programasCustomizados = new List<ProgramaAquecimentoCustomizado>();
        }

        public Microondas(int v, object twm)
        {
            this.v = v;
            this.twm = twm;
        }

        public Microondas()
        {
        }

        public void Aquecer(int tempo, int potencia)
        {
            if (_aquecendo)
            {
                Console.WriteLine("Aquecimento em andamento. Para iniciar novo aquecimento, cancele o atual.");
                return;
            }

            if (tempo < _tempoMinimo || tempo > _tempoMaximo)
            {
                Console.WriteLine($"Tempo inválido. O tempo deve estar entre {_tempoMinimo} e {_tempoMaximo} segundos.");
                return;
            }

            if (potencia < 1 || potencia > 10)
            {
                Console.WriteLine("Potência inválida. A potência deve estar entre 1 e 10.");
                return;
            }

            _tempo = tempo;
            _potencia = potencia;
            _aquecendo = true;

            Console.WriteLine("Iniciando aquecimento...");
            Console.WriteLine(ObterStringAquecimento(tempo, potencia));

            for (int segundoAtual = 1; segundoAtual <= tempo; segundoAtual++)
            {
                Console.WriteLine(ObterProgressoAquecimento(segundoAtual, potencia));
                System.Threading.Thread.Sleep(1000);
            }

            Console.WriteLine("Aquecimento concluído.");
            _aquecendo = false;
        }

        public void InicioRapido()
        {
            if (_aquecendo)
            {
                Console.WriteLine("Aquecimento em andamento. Para iniciar novo aquecimento, cancele o atual.");
                return;
            }

            _tempo = 30;
            _potencia = _potenciaPadrao;
            _aquecendo = true;

            Console.WriteLine("Iniciando aquecimento rápido...");
            Console.WriteLine(ObterStringAquecimento(_tempo, _potencia));

            for (int segundoAtual = 1; segundoAtual <= _tempo; segundoAtual++)
            {
                Console.WriteLine(ObterProgressoAquecimento(segundoAtual, _potencia));
                System.Threading.Thread.Sleep(1000);
            }

            Console.WriteLine("Aquecimento concluído.");
            _aquecendo = false;
        }

        public void PausarCancelar()
        {
            if (_aquecendo)
            {
                Console.WriteLine("Aquecimento pausado/cancelado.");
                _tempo = 0;
                _potencia = _potenciaPadrao;
                _aquecendo = false;
            }
            else
            {
                Console.WriteLine("Nenhum aquecimento em andamento para pausar/cancelar.");
            }
        }

        public void ExibirProgramasPreDefinidos()
        {
            Console.WriteLine("Programas pré-definidos:");

            Console.WriteLine("1. Nome: Pipoca");
            Console.WriteLine("   Alimento: Pipoca (de micro-ondas)");
            Console.WriteLine("   Tempo: 3 minutos");
            Console.WriteLine("   Potência: 7");
            Console.WriteLine("   Instruções: Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um estouro e outro, interrompa o aquecimento.");

            Console.WriteLine("2. Nome: Leite");
            Console.WriteLine("   Alimento: Leite");
            Console.WriteLine("   Tempo: 5 minutos");
            Console.WriteLine("   Potência: 5");
            Console.WriteLine("   Instruções: Cuidado com aquecimento de líquidos, o choque térmico aliado ao movimento do recipiente pode causar fervura imediata causando risco de queimaduras.");

            Console.WriteLine("3. Nome: Carnes de boi");
            Console.WriteLine("   Alimento: Carne em pedaço ou fatias");
            Console.WriteLine("   Tempo: 14 minutos");
            Console.WriteLine("   Potência: 4");
            Console.WriteLine("   Instruções: Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme.");

            Console.WriteLine("4. Nome: Frango");
            Console.WriteLine("   Alimento: Frango (qualquer corte)");
            Console.WriteLine("   Tempo: 8 minutos");
            Console.WriteLine("   Potência: 7");
            Console.WriteLine("   Instruções: Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o descongelamento uniforme.");

            Console.WriteLine("5. Nome: Feijão");
            Console.WriteLine("   Alimento: Feijão congelado");
            Console.WriteLine("   Tempo: 8 minutos");
            Console.WriteLine("   Potência: 9");
            Console.WriteLine("   Instruções: Deixe o recipiente destampado e em casos de plástico, cuidado ao retirar o recipiente pois o mesmo pode perder resistência em altas temperaturas.");
        }

        public void SelecionarProgramaPreDefinido(int indicePrograma)
        {
            switch (indicePrograma)
            {
                case 1:
                    _tempo = 180;
                    _potencia = 7;
                    break;
                case 2:
                    _tempo = 300;
                    _potencia = 5;
                    break;
                case 3:
                    _tempo = 840;
                    _potencia = 4;
                    break;
                case 4:
                    _tempo = 480;
                    _potencia = 7;
                    break;
                case 5:
                    _tempo = 480;
                    _potencia = 9;
                    break;
                default:
                    Console.WriteLine("Índice inválido. Selecione um programa pré-definido válido.");
                    break;
            }
        }

        public void CadastrarProgramaCustomizado(string nome, string alimento, int tempo, int potencia, string caractereAquecimento, string instrucoes)
        {
            if (ExisteCaractereAquecimento(caractereAquecimento) || caractereAquecimento == ".")
            {
                Console.WriteLine("Caractere de aquecimento inválido. O caractere não pode ser repetido com outros programas e não pode ser o caractere padrão '.'.");
                return;
            }

            ProgramaAquecimentoCustomizado programaCustomizado = new ProgramaAquecimentoCustomizado(nome, alimento, tempo, potencia, caractereAquecimento, instrucoes);
            _programasCustomizados.Add(programaCustomizado);

            Console.WriteLine("Programa customizado cadastrado com sucesso.");
        }

        private bool ExisteCaractereAquecimento(string caractereAquecimento)
        {
            throw new NotImplementedException();
        }

        public void ExibirProgramasCustomizados()
        {
            if (_programasCustomizados.Count == 0)
            {
                Console.WriteLine("Nenhum programa customizado cadastrado.");
                return;
            }

            Console.WriteLine("Programas customizados:");

            int indice = 1;
            foreach (var programa in _programasCustomizados)
            {
                Console.WriteLine($"#{indice}");
                Console.WriteLine($"Nome: {programa.Nome}");
                Console.WriteLine($"Alimento: {programa.Alimento}");
                Console.WriteLine($"Tempo: {programa.Tempo} segundos");
                Console.WriteLine($"Potência: {programa.Potencia}");
                Console.WriteLine($"Caractere de aquecimento: {programa.CaractereAquecimento}");
                Console.WriteLine($"Instruções: {programa.Instrucoes}");
                Console.WriteLine("----------");
                indice++;
            }
        }

        private string ObterStringAquecimento(int tempo, int potencia)
        {
            StringBuilder stringAquecimento = new StringBuilder();

            char caractereAquecimento = '#';

            if (tempo < 60)
            {
                for (int i = 0; i < potencia; i++)
                {
                    stringAquecimento.Append(caractereAquecimento);
                    stringAquecimento.Append(" ");
                }
            }
            else
            {
                int minutos = tempo / 60;
                int segundos = tempo % 60;

                for (int i = 0; i < minutos; i++)
                {
                    stringAquecimento.Append(caractereAquecimento);
                    stringAquecimento.Append(" ");
                }

                for (int i = 0; i < segundos; i++)
                {
                    stringAquecimento.Append(caractereAquecimento);
                }
            }

            return stringAquecimento.ToString();
        }

        private string ObterProgressoAquecimento(int segundoAtual, int potencia)
        {
            StringBuilder progresso = new StringBuilder();

            char caractereAquecimento = '#';

            for (int i = 1; i <= potencia; i++)
            {
                progresso.Append(caractereAquecimento + " ");
            }

            if (segundoAtual == tempo)
            {
                progresso.Append("Aquecimento concluído");
            }

            return progresso.ToString();
        }



    }
}
