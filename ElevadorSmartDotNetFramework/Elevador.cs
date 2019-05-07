using System;
using System.Collections.Generic;
using System.Text;

namespace ElevadorSmartDotNetFramework
{
    public static class Elevador
    {
        private static int posAtual;
        private static int iProximaParada;
        private static string sProximaParada;

        public static void Run(List<Passageiro> lstPassageiro, int posAtualElevador)
        {
            posAtual = posAtualElevador;
            List<Passageiro> lstPassageiroNew;

            if (lstPassageiro.Count > 0)
            {
                int menorValor = int.MaxValue;

                foreach (Passageiro pass in lstPassageiro)
                {
                    if ((posAtual == pass.PosIncial) && (pass.Wait))
                    {
                        Console.WriteLine("====== Abre a porta para pegar o " + pass.NomePassageiro + " no mesmo andar: " + posAtual.ToString("00") + "º Andar ======");
                        Console.WriteLine("");
                        pass.Wait = false;
                    }

                    if ((pass.Wait == true) && (Math.Abs(pass.PosIncial - posAtual) < menorValor))
                    {
                        menorValor = Math.Abs(pass.PosIncial - posAtual);
                        iProximaParada = pass.PosIncial;
                    }
                    else if ((pass.Wait == false) && (Math.Abs(pass.PosDestino - posAtual) < menorValor))
                {
                        menorValor = Math.Abs(pass.PosDestino - posAtual);
                        iProximaParada = pass.PosDestino;
                    }
                }

                if (iProximaParada == 0)
                    sProximaParada = "Térreo";
                else
                    sProximaParada = iProximaParada.ToString("00") + "º Andar";

                Console.WriteLine("Próxima parada: " + sProximaParada);

                posAtual = iProximaParada;
                lstPassageiroNew = new List<Passageiro>();

                foreach (Passageiro pass in lstPassageiro)
                {
                    if ((pass.Wait == true) && (posAtual == pass.PosIncial))
                    {
                        pass.Wait = false;
                        lstPassageiroNew.Add(pass);
                    }
                    else if (!((pass.Wait == false) && (posAtual == pass.PosDestino)))
                    {
                        lstPassageiroNew.Add(pass);
                    }

                }

                if (lstPassageiroNew.Count > 0)
                {
                    Run(lstPassageiroNew, posAtual);
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Fim do Percurso. Elevador aguardando próxima chamada...".ToUpper());
                    Console.WriteLine("");
                }
                
            }
        }


    }
}
