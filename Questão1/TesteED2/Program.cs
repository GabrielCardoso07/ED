using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificacaoSintatica
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testando a verificação sintática com as strings fornecidas
            string expressao1 = "{ 5 * [ a + b] - d * (c - a) + log10 }";
            string expressao2 = "{ 5 * [ a + b] - d * (c - a] + log10 }";
            bool resultado1 = VerificarSintaxe(expressao1);
            bool resultado2 = VerificarSintaxe(expressao2);

            Console.WriteLine($"Expressão 1: {expressao1}");
            Console.WriteLine($"Resultado da verificação sintática: {resultado1}");
            Console.WriteLine();

            Console.WriteLine($"Expressão 2: {expressao2}");
            Console.WriteLine($"Resultado da verificação sintática: {resultado2}");
            Console.ReadKey();
        }

        static bool VerificarSintaxe(string expressao)
        {
            Stack<char> pilha = new Stack<char>();
            char caractere;

            for (int i = 0; i < expressao.Length; i++)
            {
                caractere = expressao[i];

                // Se o caractere for uma abertura de parênteses, colchetes ou chaves, empilha
                if (caractere == '(' || caractere == '[' || caractere == '{')
                {
                    pilha.Push(caractere);
                }
                // Se o caractere for um fechamento de parênteses, colchetes ou chaves
                else if (caractere == ')' || caractere == ']' || caractere == '}')
                {
                    // Verifica se a pilha está vazia (ou seja, se não há abertura correspondente)
                    if (pilha.Count == 0)
                    {
                        return false;
                    }
                    // Verifica se o topo da pilha é correspondente ao fechamento atual
                    char topo = pilha.Peek();
                    if ((topo == '(' && caractere == ')') || (topo == '[' && caractere == ']') || (topo == '{' && caractere == '}'))
                    {
                        pilha.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            // Se a pilha estiver vazia, significa que todas as aberturas foram fechadas corretamente
            return pilha.Count == 0;
        }
    }
}
