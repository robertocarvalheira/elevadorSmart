using System;
using System.Collections.Generic;

namespace ElevadorSmartDotNetFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            int qtdePassageiros;
            int posAtualElevador;
            List<Passageiro> lstPassageiros = new List<Passageiro>();

            Console.SetWindowSize(Console.LargestWindowWidth - 10, Console.LargestWindowHeight);

            Console.WriteLine("");
            Console.WriteLine("Cenário 01, considerando que ambos os passageiros solicitaram elevador ao mesmo tempo:".ToUpper());

            posAtualElevador = 5;

            lstPassageiros.Add(new Passageiro("Passageiro 01", 8, 0));
            lstPassageiros.Add(new Passageiro("Passageiro 02", 0, 10));

            Console.WriteLine("");
            Elevador.Run(lstPassageiros, posAtualElevador);

            Console.WriteLine("");
            Console.WriteLine("Cenário 02, considerando que ambos os passageiros solicitaram elevador ao mesmo tempo:".ToUpper());

            posAtualElevador = 3;

            lstPassageiros.Clear();

            lstPassageiros.Add(new Passageiro("Passageiro 03", 3, 15));
            lstPassageiros.Add(new Passageiro("Passageiro 01", 8, 0));
            lstPassageiros.Add(new Passageiro("Passageiro 02", 0, 7));

            Console.WriteLine("");
            ElevadorDoisBotoes.Run(lstPassageiros, posAtualElevador);

            lstPassageiros.Clear();
            Console.WriteLine("");
            Console.WriteLine("Cenário 03, considerando algoritmo genérico onde o usuário vai informar os dados:".ToUpper());
            Console.WriteLine("");
            Console.Write("Informe a posição atual do elevador: ");
            posAtualElevador = Convert.ToInt16(Console.ReadLine());

            Console.Write("Informe a quantidade de passageiros solicitando elevador no momento: ");
            qtdePassageiros = Convert.ToInt16(Console.ReadLine());

            if (qtdePassageiros > 0)
            {
                for (int i = 1; i <= qtdePassageiros; i++)
                {
                    Console.WriteLine("");
                    Console.Write("Informe o nome do passageiro " + i.ToString() + ": ");
                    string nome = Console.ReadLine();
                    Console.Write("Informe o andar atual do passageiro " + nome + ": ");
                    int andarAtual = Convert.ToInt16((Console.ReadLine()));
                    Console.Write("Informe o andar de destino do passageiro " + nome + ": ");
                    int andarDestino = Convert.ToInt16((Console.ReadLine()));
                    lstPassageiros.Add(new Passageiro(nome, andarAtual, andarDestino));
                }
            }

            Console.WriteLine("");

            ElevadorDoisBotoes.Run(lstPassageiros, posAtualElevador);

            Console.WriteLine("");
            Console.WriteLine("Cenário 02, considerando que ambos os passageiros solicitaram elevador ao mesmo tempo:".ToUpper());

        }
    }

}
