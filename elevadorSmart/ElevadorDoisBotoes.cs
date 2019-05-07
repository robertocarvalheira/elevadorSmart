using System;
using System.Collections.Generic;
using System.Text;

namespace ElevadorSmartDotNetFramework
{
    public static class ElevadorDoisBotoes
    {
        private static int posAtual;
        private static int iProximaParada = -1;
        private static string sProximaParada;
        private static int direcaoDestino = -1;
        private static int direcaoDestinoInicial = -1;
        private static string passageiroInicial;
        public enum EDirecaoDestino: int
        {
            subir = 0,
            descer = 1
        }

        public static void Run(List<Passageiro> lstPassageiro, int posAtualElevador)
        {
            posAtual = posAtualElevador;
            List<Passageiro> lstPassageiroNew;

            if (lstPassageiro.Count > 0)
            {
                int menorValor = int.MaxValue;
                bool enviaMsgMesmoAndar = false;

                foreach (Passageiro pass in lstPassageiro)
                {

                    if (pass.PosIncial < pass.PosDestino)
                        pass.DirecaoDestino = (int)EDirecaoDestino.subir;
                    else
                        pass.DirecaoDestino = (int)EDirecaoDestino.descer;

                    if ((posAtual == pass.PosIncial) && (pass.Wait))
                    {
                        enviaMsgMesmoAndar = true;
                        direcaoDestinoInicial = pass.DirecaoDestino;
                        passageiroInicial = pass.NomePassageiro;
                        pass.Wait = false;
                    }

                    if ((pass.Wait == false) && (Math.Abs(pass.PosDestino - posAtual) < menorValor) && ((direcaoDestino == pass.DirecaoDestino) || (direcaoDestino == -1)))
                    {
                        menorValor = Math.Abs(pass.PosDestino - posAtual);
                        iProximaParada = pass.PosDestino;
                    }
                    else if ((pass.Wait == true) && (Math.Abs(pass.PosIncial - posAtual) < menorValor) && ((direcaoDestino == pass.DirecaoDestino) || (direcaoDestino == -1)))
                    {
                        menorValor = Math.Abs(pass.PosIncial - posAtual);
                        iProximaParada = pass.PosIncial;
                    }

                    if (iProximaParada > posAtual)
                        direcaoDestino = (int)EDirecaoDestino.subir;
                    else if (iProximaParada < posAtual)
                        direcaoDestino = (int)EDirecaoDestino.descer;
                }

                if (enviaMsgMesmoAndar && (direcaoDestino == direcaoDestinoInicial))
                {
                    Console.WriteLine("====== Abre a porta para pegar o " + passageiroInicial + " no mesmo andar: " + posAtual.ToString("00") + "º Andar ======");
                    Console.WriteLine("");
                }
                else if (enviaMsgMesmoAndar && (direcaoDestino != direcaoDestinoInicial))
                {
                    Passageiro passageiro = lstPassageiro.Find(item => item.NomePassageiro == passageiroInicial);
                    passageiro.Wait = true;
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
                    if (lstPassageiroNew.Exists(x => x.Wait == false))
                    {
                        Passageiro pass = lstPassageiroNew.Find(item => item.Wait == false);
                        if (pass.PosDestino > posAtual)
                            direcaoDestino = (int)EDirecaoDestino.subir;
                        else if (pass.PosDestino < posAtual)
                            direcaoDestino = (int)EDirecaoDestino.descer;
                    }
                    else
                    {
                        Passageiro pass = lstPassageiroNew.Find(item => item.Wait == true);
                        if (pass.PosDestino > posAtual)
                            direcaoDestino = (int)EDirecaoDestino.subir;
                        else if (pass.PosDestino < posAtual)
                            direcaoDestino = (int)EDirecaoDestino.descer;
                        else
                            direcaoDestino = -1;
                    }             

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
