using System;
using System.Collections.Generic;
using System.Text;

namespace ElevadorSmartDotNetFramework
{
    public class Passageiro : IPassageiro
    {
        private int posInicial;
        private int posdestino;
        private bool wait;
        private string nomePassageiro;
        private int direcaoDestino = -1;

        public enum EDirecaoDestino
        {
            subir,
            descer
        }
        public Passageiro(string nome, int origem, int destino)
        {
            this.wait = true;
            this.nomePassageiro = nome;
            this.posInicial = origem;
            this.posdestino = destino;
        }

        public int DirecaoDestino
        {
            get { return this.direcaoDestino; }
            set { this.direcaoDestino = value; }
        }
        public int PosIncial
        {
            get { return this.posInicial; }
            set { this.posInicial = value; }
        }
        public int PosDestino
        {
            get { return this.posdestino; }
            set { this.posdestino = value; }
        }
        public bool Wait
        {
            get { return this.wait; }
            set { this.wait = value; }
        }
        public string NomePassageiro
        {
            get { return this.nomePassageiro; }
            set { this.nomePassageiro = value; }
        }
    }
}
