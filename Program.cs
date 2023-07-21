using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMicroondasDigital
{
    class Program
    {
        static void Main()
        {
            IMicroondas microondas = new Microondas();
            int opcao;

            do
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Iniciar aquecimento");
                Console.WriteLine("2 - Início rápido");
                Console.WriteLine("3 - Pausar/Cancelar");
                Console.WriteLine("4 - Exibir programas pré-definidos");
                Console.WriteLine("5 - Selecionar programa pré-definido");
                Console.WriteLine("0 - Sair");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite o tempo em segundos: ");
                        int tempo = int.Parse(Console.ReadLine());
                        Console.Write("Digite a potência (1 a 10): ");
                        int potencia = int.Parse(Console.ReadLine());
                        microondas.Aquecer(tempo, potencia);
                        break;
                    case 2:
                        microondas.InicioRapido();
                        break;
                    case 3:
                        microondas.PausarCancelar();
                        break;
                    case 4:
                        microondas.ExibirProgramasPreDefinidos();
                        break;
                    case 5:
                        Console.Write("Digite o índice do programa pré-definido: ");
                        int indicePrograma = int.Parse(Console.ReadLine());
                        microondas.SelecionarProgramaPreDefinido(indicePrograma);
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine();
            } while (opcao != 0);
        }
    }
}
