using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao2_1Prova
{
    
        class Program
        {
            static bool[] vagas = new bool[10]; // Array para armazenar as vagas do estacionamento

            static void Main(string[] args)
            {
                while (true)
                {

                    Console.WriteLine("Digite 1 para registrar a chegada de um carro ou 2 para registrar a saída de um carro: ");
                    int opcao = int.Parse(Console.ReadLine()); // Lê a opção escolhida pelo usuário

                    if (opcao == 1)
                    {
                        RegistrarChegada();
                    }
                    else if (opcao == 2)
                    {
                        RegistrarSaida();
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida!");
                    }
                }
            }

            static void RegistrarChegada()
            {
                bool vagaDisponivel = false;
                int vaga = 0;

                for (int i = vagas.Length - 1; i >=0; i--)
                {
                    if (!vagas[i])
                    {
                        vagaDisponivel = true;
                        vaga = i + 1;
                        vagas[i] = true;
                        break;
                    }
                }

                if (vagaDisponivel)
                {
                    Console.WriteLine("Carro estacionado na vaga {0}", vaga);
                }
                else
                {
                    Console.WriteLine("Não há vagas disponíveis");
                }
            }

            static void RegistrarSaida()
            {
                Console.WriteLine("Digite o número da vaga que quer liberar: ");
                int vaga = int.Parse(Console.ReadLine());

                if (vagas[vaga - 1])
                {
                    vagas[vaga - 1] = false;
                    Console.WriteLine("Carro liberado da vaga {0}", vaga);
                    int n =  vaga;
                    

                    // Verifica se há carros bloqueando a saída e remove-os, se necessário
                    for (int i = 0; i < vagas.Length; i++)
                    {
                        if (vagas[i])
                        {
                            vagas[i] = false;
                            Console.WriteLine("Carro removido da vaga {0}", i + 1);
                            
                        }
                        else
                        {
                            break;
                        }
                    }

                    // Reestaciona os carros que foram removidos
                    for (int i = 1; i < vagas.Length; i++)
                    {
                        if (i !=n)
                        {
                            vagas[i] = true;
                            Console.WriteLine("Carro estacionado na vaga {0}", i + 1);
                            
                        }
                        else
                        {
                            break;
                        }
                        
                     }
            }  
                else
                {
                    Console.WriteLine("Não há carro na vaga {0}", vaga);
                }
            }
        }
    

}
